using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using HappyVacation.Database;
using HappyVacation.Database.Entities;
using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Orders;
using HappyVacation.Services.Email;
using HappyVacation.Services.QRCodeGen;
using HappyVacation.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using HappyVacation.Services.XLSX;

namespace HappyVacation.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;
        private readonly IEmailService _emailService;
        private IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IXLSXService _xlsxService;

        public OrderRepository(MyDbContext context, IEmailService emailService, IConfiguration configuration, 
                                    IHttpClientFactory httpClientFactory, IXLSXService xlsxService)
        {
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _xlsxService = xlsxService;
        }

        public async Task<int> CreateOrder(int userId, CreateTourOrderRequest request)
        {
            var tour_start_end = await _context.Tours.Where(x => x.Id == request.TourId)
                .Select(x => new { startPoint = x.StartPoint, endPoint = x.EndPoint })
                .FirstOrDefaultAsync();

            var order = new Database.Entities.Order()
            {
                UserId = userId,
                TourId = request.TourId,
                DepartureDate = DateTime.ParseExact(request.DepartureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                StartPoint = !String.IsNullOrEmpty(request.StartPoint) ? request.StartPoint : tour_start_end.startPoint,
                EndPoint = !String.IsNullOrEmpty(request.EndPoint) ? request.EndPoint : tour_start_end.endPoint,
                Adults = request.Adults,
                Children = request.Children,
                TouristIdentityNum = request.TouristIdentity,
                TouristName = request.TouristName,
                TouristPhone = request.TouristPhone,
                TouristEmail = request.TouristEmail,
                OrderDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                State = "confirmed",
                TransactionId = request.TransactionId
            };

            // order members
            var orderMembers = new List<OrderMember>();
            foreach(var item in request.AdultsList)
            {
                orderMembers.Add(new OrderMember()
                {
                    IdentityNum = item.IdentityNumber,
                    FullName = $"{item.FirstName} {item.LastName}",
                    DateOfBirth = DateTime.ParseExact(item.Dob, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsChild = false,
                });
            }
            foreach (var item in request.ChildrenList)
            {
                orderMembers.Add(new OrderMember()
                {
                    IdentityNum = item.IdentityNumber,
                    FullName = $"{item.FirstName} {item.LastName}",
                    DateOfBirth = DateTime.ParseExact(item.Dob, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsChild = true,
                });
            }
            order.OrderMembers = orderMembers;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // send confirmation email
            var newOrder = await _context.Orders.Include(x => x.Tour).ThenInclude(t => t.Provider).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == order.Id);
            SendConfirmationEmail(newOrder);

            // fire new notification 
            var providerId = await _context.Tours.Where(x => x.Id == request.TourId).Select(x => x.ProviderId).FirstOrDefaultAsync();

            if (FirebaseApp.DefaultInstance == null) 
            { 
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("private_firebase_admin_key.json")

                });          
            }

            // The topic name can be optionally prefixed with "/topics/".
            var topic = $"Tour_Provider_{providerId}";

            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "type", "tour" },
                    { "provider", providerId.ToString() }
                },
                Topic = topic,
                Notification = new Notification()
                {
                    Title = "New tour order",
                    Body = "You have a new pending order"
                }
            };

            // Send a message to the devices subscribed to the provided topic.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);

            return order.Id;
        }

        public async Task<string> CreateOrderPayment(int userId, CreateTourOrderRequest request)
        {
            // create order 
            var tour_start_end = await _context.Tours.Where(x => x.Id == request.TourId)
                .Select(x => new { startPoint = x.StartPoint, endPoint = x.EndPoint })
                .FirstOrDefaultAsync();

            var myOrder = new Database.Entities.Order()
            {
                UserId = userId,
                TourId = request.TourId,
                DepartureDate = DateTime.ParseExact(request.DepartureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                StartPoint = !String.IsNullOrEmpty(request.StartPoint) ? request.StartPoint : tour_start_end.startPoint,
                EndPoint = !String.IsNullOrEmpty(request.EndPoint) ? request.EndPoint : tour_start_end.endPoint,
                Adults = request.Adults,
                Children = request.Children,
                TouristIdentityNum = request.TouristIdentity,
                TouristName = request.TouristName,
                TouristPhone = request.TouristPhone,
                TouristEmail = request.TouristEmail,
                OrderDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                State = "pending",
                TransactionId = "",
            };

            // order members
            var orderMembers = new List<OrderMember>();
            foreach (var item in request.AdultsList)
            {
                orderMembers.Add(new OrderMember()
                {
                    IdentityNum = item.IdentityNumber,
                    FullName = $"{item.FirstName} {item.LastName}",
                    DateOfBirth = DateTime.ParseExact(item.Dob, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsChild = false,
                });
            }
            foreach (var item in request.ChildrenList)
            {
                orderMembers.Add(new OrderMember()
                {
                    IdentityNum = item.IdentityNumber,
                    FullName = $"{item.FirstName} {item.LastName}",
                    DateOfBirth = DateTime.ParseExact(item.Dob, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsChild = true,
                });
            }
            myOrder.OrderMembers = orderMembers;

            _context.Orders.Add(myOrder);
            await _context.SaveChangesAsync();

            // get order's payment info
            var paymentInfo = await GetOrderPaymentInfoAsync(myOrder.Id);
            // create paypal payment/order
            var environment = new SandboxEnvironment(_configuration["Paypal:ClientId"], _configuration["Paypal:SecretKey"]);
            var payPalClient = new PayPalHttpClient(environment);
            #region Create Paypal order
            PayPalHttp.HttpResponse response;
            // Construct a request object and set desired parameters
            // Here, OrdersCreateRequest() creates a POST request to /v2/checkout/orders

            var paypalOrder = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>()
                {
                    new PurchaseUnitRequest()
                    {
                        AmountWithBreakdown = new AmountWithBreakdown()
                        {
                            CurrencyCode = "USD",
                            Value = paymentInfo.TotalPrice.ToString(),
                        },
                        Description = $"{paymentInfo.TourName} from {paymentInfo.ProviderName}",
                        InvoiceId = paymentInfo.OrderId.ToString()
                    }
                },
                ApplicationContext = new ApplicationContext()
                {
                    ReturnUrl = $"http://localhost:3000/checkout/successed?orderId={paymentInfo.OrderId}",
                    CancelUrl = $"http://localhost:3000/checkout/failed?orderId={paymentInfo.OrderId}"
                }
            };

            // Call API with your client and get a response for your call
            var payPalRequest = new OrdersCreateRequest();
            payPalRequest.Prefer("return=representation");
            payPalRequest.RequestBody(paypalOrder);
            response = await payPalClient.Execute(payPalRequest);
            var statusCode = response.StatusCode;
            PayPalCheckoutSdk.Orders.Order result = response.Result<PayPalCheckoutSdk.Orders.Order>();
            Console.WriteLine("Status: {0}", result.Status);
            Console.WriteLine("Order Id: {0}", result.Id);
            Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
            Console.WriteLine("Links:");
            // saving the paypal redirect url to which user will be redirected for payment
            var payPalRedirectUrl = "";
            foreach (LinkDescription link in result.Links)
            {
                if(link.Rel.ToLower().Trim().Equals("approve"))
                {
                    payPalRedirectUrl = link.Href;
                }
                Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
            }
            #endregion


            return payPalRedirectUrl;
        }

        public async Task<OrderPaymentInfoVm> ConfirmOrderTransaction(int orderId, string transactionId)
        {
            var NOT_FOUND_ERROR = -1;
            var PAYPAL_API_ERROR = -2;
            var ALREADY_CONFIRMED_ERROR = 0;

            var myOrder = await _context.Orders.Include(x => x.Tour).ThenInclude(t => t.Provider).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == orderId);
            // check if order exist
            if (myOrder == null)
            {
                return null;
            }
            else
            {
                if(myOrder.State.Equals("confirmed") || !String.IsNullOrEmpty(myOrder.TransactionId))
                {
                    return new OrderPaymentInfoVm()
                    {
                        OrderId = myOrder.Id,
                        TourName = myOrder.Tour.TourName,
                        ProviderName = myOrder.Tour.Provider.ProviderName,
                        TotalPrice = myOrder.Adults * myOrder.Tour.PricePerAdult + myOrder.Children * myOrder.Tour.PricePerChild
                    };
                }
            }
            // check orderId(invoiceId) with transactionId
            // 1. get paypal access_token
            var access_token = await GetPaypalAcessTokenAsync();
            if(access_token == null)
            {
                return null;
            }
            // 2. check order and transaction id
            if (await CheckOrderTransactionId(orderId, transactionId, access_token))
            {
                // update order's transaction id
                myOrder.TransactionId = transactionId;
                myOrder.State = "confirmed";
                // fire notification
                await FireNotificationAsync(myOrder.Tour.Provider.Id);
                // send email
                SendConfirmationEmail(myOrder);
                // update database
                _context.Orders.Update(myOrder);
                await _context.SaveChangesAsync();

                return new OrderPaymentInfoVm()
                {
                    OrderId = myOrder.Id,
                    TourName = myOrder.Tour.TourName,
                    ProviderName = myOrder.Tour.Provider.ProviderName,
                    TotalPrice = myOrder.Adults * myOrder.Tour.PricePerAdult + myOrder.Children * myOrder.Tour.PricePerChild
                };
            }
            else
            {
                return null;
            }
        }


        public async Task<OrderManageInfoVm> GetOrderById(int orderId)
        {
            var query = _context.Orders.Where(x => x.Id == orderId).AsNoTracking();

            var order = await query.Select(x => new OrderManageInfoVm()
            {
                Id = x.Id,
                TourId = x.TourId,
                TourName = x.Tour.TourName,
                DepartureDate = x.DepartureDate.ToString("dd/MM/yyyy"),
                HasDeparted = x.DepartureDate.Date < DateTime.Now.Date,
                OrderDate = x.OrderDate.ToString("dd/MM/yyyy"),
                ModifiedDate = x.ModifiedDate.ToString("dd/MM/yyyy"),
                Duration = x.Tour.Duration,
                IsPrivate = x.Tour.IsPrivate,
                Adults = x.Adults,
                Children = x.Children,
                PricePerAdult = x.Tour.PricePerAdult,
                PricePerChild = x.Tour.PricePerChild,
                TotalPrice = x.Adults * x.Tour.PricePerAdult + x.Children * x.Tour.PricePerChild,
                ThumbnailUrl = (x.Tour.TourImages.Count() > 0) ? x.Tour.TourImages[0].Url : String.Empty,
                State = x.State,
                TouristName = x.TouristName,
                TouristPhone = x.TouristPhone,
                TouristEmail = x.TouristEmail,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
            }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<OrderManageDetailVm> GetOrderDetailManage(int userId, int orderId)
        {
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();

            if (!_context.Orders.Any(x => (x.Id == orderId) && (x.Tour.ProviderId == providerId)))
            {
                return null;
            }

            var query = _context.Orders.Where(x => x.Id == orderId).AsNoTracking();

            var order = await query.Select(x => new OrderManageDetailVm()
            {
                Id = x.Id,
                TourId = x.TourId,
                TourName = x.Tour.TourName,
                DepartureDate = x.DepartureDate.ToString("dd/MM/yyyy"),
                HasDeparted = x.DepartureDate.Date < DateTime.Now.Date,
                OrderDate = x.OrderDate.ToString("dd/MM/yyyy"),
                ModifiedDate = x.ModifiedDate.ToString("dd/MM/yyyy"),
                Duration = x.Tour.Duration,
                IsPrivate = x.Tour.IsPrivate,
                Adults = x.Adults,
                Children = x.Children,
                PricePerAdult = x.Tour.PricePerAdult,
                PricePerChild = x.Tour.PricePerChild,
                TotalPrice = x.Adults * x.Tour.PricePerAdult + x.Children * x.Tour.PricePerChild,
                ThumbnailUrl = (x.Tour.TourImages.Count() > 0) ? x.Tour.TourImages[0].Url : String.Empty,
                State = x.State,
                TouristName = x.TouristName,
                TouristPhone = x.TouristPhone,
                TouristEmail = x.TouristEmail,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                AdultsList = x.OrderMembers.Where(om => om.IsChild == false).Select(om => new AdultVm()
                {
                    IdentityNumber = om.IdentityNum,
                    FullName = om.FullName,
                    Dob = om.DateOfBirth.ToString("dd/MM/yyyy")
                }),
                ChildrenList = x.OrderMembers.Where(om => om.IsChild == true).Select(om => new ChildVm()
                {
                    IdentityNumber = om.IdentityNum,
                    FullName = om.FullName,
                    Dob = om.DateOfBirth.ToString("dd/MM/yyyy")
                })
            }).FirstOrDefaultAsync();

            return order;
        }
        public async Task<OrderDetailVm> GetOrderDetail(int userId, int orderId)
        {
            if (!_context.Orders.Any(x => (x.Id == orderId) && (x.UserId == userId)))
            {
                return null;
            }

            var query = _context.Orders.Where(x => x.Id == orderId).AsNoTracking();

            var order = await query.Select(x => new OrderDetailVm()
            {
                Id = x.Id,
                TourId = x.TourId,
                TourName = x.Tour.TourName,
                OrderDate = x.OrderDate.ToString("dd/MM/yyyy"),
                DepartureDate = x.DepartureDate.ToString("dd/MM/yyyy"),
                HasDeparted = x.DepartureDate.Date < DateTime.Now.Date,
                ModifiedDate = x.ModifiedDate.ToString("dd/MM/yyyy"),
                Duration = x.Tour.Duration,
                IsPrivate = x.Tour.IsPrivate,
                Adults = x.Adults,
                Children = x.Children,
                PricePerAdult = x.Tour.PricePerAdult,
                PricePerChild = x.Tour.PricePerChild,
                TotalPrice = x.Adults * x.Tour.PricePerAdult + x.Children * x.Tour.PricePerChild,
                ThumbnailUrl = (x.Tour.TourImages.Count() > 0) ? x.Tour.TourImages[0].Url : String.Empty,
                State = x.State,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                AdultsList = x.OrderMembers.Where(om => om.IsChild == false).Select(om => new AdultVm()
                {
                    IdentityNumber = om.IdentityNum,
                    FullName = om.FullName,
                    Dob = om.DateOfBirth.ToString("dd/MM/yyyy")
                }),
                ChildrenList = x.OrderMembers.Where(om => om.IsChild == true).Select(om => new ChildVm()
                {
                    IdentityNumber = om.IdentityNum,
                    FullName = om.FullName,
                    Dob = om.DateOfBirth.ToString("dd/MM/yyyy")
                }),
                ProviderId = x.Tour.ProviderId,
                ProviderName = x.Tour.Provider.ProviderName,     
                ProviderPhone = x.Tour.Provider.ProviderPhone,
                ProviderEmail = x.Tour.Provider.ProviderEmail
            }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<PagedResult<OrderManageInfoVm>> GetTourProviderOrders(int userId, string state, int page, int perPage, string keyword)
        {
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            if(providerId == null || providerId == 0)
            {
                return null;
            }

            var query = _context.Orders.Where(x => x.Tour.ProviderId == providerId).AsNoTracking();

            // filter by keyword tourist info
            if (!string.IsNullOrEmpty(keyword))
            {
                // by order Id
                int orderId;
                if (int.TryParse(keyword, out orderId))
                {
                    query = query.Where(x => (x.Id == orderId));
                }
                var phoneRegex = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
                // by phone
                if(phoneRegex.IsMatch(keyword))
                {
                    query = query.Where(x => (x.TouristPhone.Contains(keyword)));
                }
                // by email
                if(EmailValid.IsValid(keyword))
                {
                    query = query.Where(x => (x.TouristEmail.Contains(keyword)));
                }
                // by name
                if(!EmailValid.IsValid(keyword) && !phoneRegex.IsMatch(keyword) && !int.TryParse(keyword, out orderId))
                {
                    query = query.Where(x => (x.TouristName.Contains(keyword)));
                }             
            }

            // filter by state
            if (!string.IsNullOrEmpty(state))
            {
                state = state.ToLower();
                if (state == "processed")
                {
                    query = query.Where(x => x.State == "confirmed" || x.State == "canceled");
                }
                else
                {
                    query = query.Where(x => x.State == state);
                }
            }

            // order by modified date
            query = query.OrderByDescending(x => x.OrderDate);

            // paging
            // default values
            page = page == 0 ? 1 : page;
            perPage = perPage == 0 ? 3 : perPage;
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / perPage) + 1;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            var orders = await query.Select(x => new OrderManageInfoVm()
            {
                Id = x.Id,
                TourId = x.TourId,
                TourName = x.Tour.TourName,
                DepartureDate = x.DepartureDate.ToString("dd/MM/yyyy"),
                HasDeparted = x.DepartureDate.Date < DateTime.Now.Date,
                OrderDate = x.DepartureDate.ToString("dd/MM/yyyy"),
                ModifiedDate = x.ModifiedDate.ToString("dd/MM/yyyy"),
                Duration = x.Tour.Duration,
                IsPrivate = x.Tour.IsPrivate,
                Adults = x.Adults,
                Children = x.Children,
                PricePerAdult = x.Tour.PricePerAdult,
                PricePerChild = x.Tour.PricePerChild,
                TotalPrice = x.Adults * x.Tour.PricePerAdult + x.Children * x.Tour.PricePerChild,
                ThumbnailUrl = (x.Tour.TourImages.Count() > 0) ? x.Tour.TourImages[0].Url : String.Empty,
                State = x.State,
                TouristName = x.TouristName,
                TouristPhone = x.TouristPhone,
                TouristEmail = x.TouristEmail,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint
            }).ToListAsync();

            return new PagedResult<OrderManageInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = orders
            };
        }

        public async Task<PagedResult<OrderMainInfoVm>> GetUserOrders(int userId, string state = "", int page = 1, int perPage = 3)
        {
            var query = _context.Orders.Where(x => x.UserId == userId).AsNoTracking();

            // filter by state
            if (!string.IsNullOrEmpty(state))
            {
                state = state.ToLower();
                if(state == "processed")
                {
                    query = query.Where(x => x.State == "confirmed" || x.State == "canceled");
                } 
                else
                {
                    query = query.Where(x => x.State == state);
                }
            }

            // order by modified date
            query = query.OrderByDescending(x => x.ModifiedDate);

            // paging
            // default values
            page = page == 0 ? 1 : page;
            perPage = perPage == 0 ? 3 : perPage;
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / perPage) + 1;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            var orders = await query.Select(x => new OrderMainInfoVm()
            {
                Id = x.Id,
                TourId = x.TourId,
                TourName = x.Tour.TourName,
                DepartureDate = x.DepartureDate.ToString("dd/MM/yyyy"),
                HasDeparted = x.DepartureDate.Date < DateTime.Now.Date,
                ModifiedDate = x.ModifiedDate.ToString("dd/MM/yyyy"),
                Duration = x.Tour.Duration,
                IsPrivate = x.Tour.IsPrivate,
                Adults = x.Adults,
                Children = x.Children,
                PricePerAdult = x.Tour.PricePerAdult,
                PricePerChild = x.Tour.PricePerChild,
                TotalPrice = x.Adults* x.Tour.PricePerAdult + x.Children* x.Tour.PricePerChild,
                ThumbnailUrl = (x.Tour.TourImages.Count() > 0) ? x.Tour.TourImages[0].Url : String.Empty,
                State = x.State,
                ProviderId = x.Tour.ProviderId,
                ProviderName = x.Tour.Provider.ProviderName,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint
            }).ToListAsync();

            return new PagedResult<OrderMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = orders
            };
        }

        public async Task<int> ConfirmOrder(int userId, int orderId)
        {       
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            var order = await _context.Orders.Include(x => x.Tour).ThenInclude(t => t.Provider).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == orderId && x.Tour.ProviderId == providerId);
            // check if provider has this order
            if(order == null)
            {
                return -1;
            }
            // change order state
            if(order.State.Equals("pending"))
            {
                order.State = "confirmed";
                order.ModifiedDate = DateTime.Now;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                var departure = order.DepartureDate.ToString("dd/MM/yyyy");
                var tourName = order.Tour.TourName.ToUpper();
                var tourStartTime = order.Tour.StartTime;
                var touristName = order.TouristName;
                var tourProvider = order.Tour.Provider.ProviderName;
                var tourProviderPhone = order.Tour.Provider.ProviderPhone;
                var tourProviderEmail = order.Tour.Provider.ProviderEmail;
                var tourProviderAddress = order.Tour.Provider.Address;

                var startPoint = order.StartPoint;
                var isStartCustomerChoice = startPoint.Split('&')[0].Equals("CustomerPoint");
                if (isStartCustomerChoice)
                {
                    startPoint = $"your chosen place: {startPoint.Split('&')[1]} in {startPoint.Split('&')[2]}";
                }
                
                var endPoint = order.EndPoint;
                var isEndCustomerChoice = endPoint.Split('&')[0].Equals("CustomerPoint");
                if (isEndCustomerChoice)
                {
                    endPoint = $"your chosen place: {endPoint.Split('&')[1]} in {endPoint.Split('&')[2]}";
                }

                // create QR code
                string qrText = $"OrderId: {order.Id}\n" +
                                $"Tour Provider: {tourProvider}\n" +
                                $"Tourist: {touristName}\n" +
                                $"Tour name: {tourName}\n" +
                                $"Depature: {departure}\n" +
                                $"Adults: {order.Adults}\n" +
                                $"Children: {order.Children}\n";

                byte[] qrCodeAsBytes = QRCodeService.CreateQRCodeAsBytes(qrText);

                // send email               
                string subject = $"You’re booked! Pack your bags – see you on {departure}!";
                string content = "<html>" +
                                    "<body> " +
                                        $"<p> Hi {touristName}, </p> " +
                                        $"<p> Your booking for {tourName} at {tourProvider} is confirmed!</p> " +
                                        $"<p> {tourProvider} will see you on {order.DepartureDate.ToString("dd/MM/yyyy")}, at {startPoint}.<br>" +
                                        $"The starting time is {tourStartTime}, you should come earlier for preparation.<br>" +
                                        $"At the end of the tour, you will be taken to {endPoint}.</p>" +

                                        $"<p> All of your tour booking information is stored in the QR code attached below. <br>" +
                                        $"You don't need to print this email for confirmation at {tourProvider}. </p>" +        
                                        $"<p> If you need to get in touch, you can contact your tour provider directly:<br>" +
                                        $"{tourProvider} <br>" +
                                        $"Phone: {tourProviderPhone} <br>" +
                                        $"Email: {tourProviderEmail} <br>" +
                                        $"Address: {tourProviderAddress} <br> <p/>" +
                                        $"<p> Thank you for booking tour on Happy Vacation. <p/>" +
                                        $"<p> Happy Vacation team. <p/>" +
                                    "</body>" +
                                 "</html>";
                _emailService.SendEmail("ngoluuquocdat@gmail.com", subject, content, qrCodeAttachment: qrCodeAsBytes);              

                return order.Id;
            } 
            else
            {
                return 0;
            }
        }     

        public async Task<int> CancelOrder(int userId, int orderId)
        {
            var NOT_FOUND_ERROR = -1;
            var PAYPAL_API_ERROR = -2;
            var ALREADY_CONFIRMED_ERROR = 0;

            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            var order = await _context.Orders.Include(x => x.Tour).ThenInclude(t => t.Provider).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == orderId && x.Tour.ProviderId == providerId);
            // check if provider has this order
            if (order == null)
            {
                return NOT_FOUND_ERROR;
            }
            // change order state
            if (order.State.Equals("pending") || order.State.Equals("confirmed"))
            {
                order.State = "canceled";
                order.ModifiedDate = DateTime.Now;             

                // refund payment
                var access_token = await GetPaypalAcessTokenAsync();
                if (access_token == null)
                {
                   return PAYPAL_API_ERROR;
                }
                if(await RefundTransaction(order.TransactionId, access_token))
                {
                    order.TransactionId = $"{order.TransactionId} - REFUNDED";
                    // update database
                    _context.Orders.Update(order);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    return PAYPAL_API_ERROR;
                }

                // send email
                var departure = order.DepartureDate.ToString("dd/MM/yyyy");
                var tourName = order.Tour.TourName.ToUpper();
                var touristName = order.TouristName;
                var tourProvider = order.Tour.Provider.ProviderName;
                var tourProviderPhone = order.Tour.Provider.ProviderPhone;
                var tourProviderEmail = order.Tour.Provider.ProviderEmail;
                var tourProviderAddress = order.Tour.Provider.Address;

                string subject = $"Booking at {tourProvider} has been canceled";

                string content = "<html>" +
                                    "<body> " +
                                        $"<p> Hi {order.TouristName}, </p> " +
                                        $"<p> We confirm your booking for {tourName} on {departure} at {tourProvider} has been canceled. <br> " +
                                        $"Your payment will be refunded, you don't have to do anything else, but if you have any question for {tourProvider}, " +
                                        $"feel free to contact them at: {tourProviderPhone} or via: {tourProviderEmail}.  </p> " +
                                        $"<p> Thank you for booking tour on Happy Vacation. <p/>" +
                                        $"<p> Happy Vacation team. <p/>" +
                                    "</body>" +
                                 "</html>";

                string content1 = $"Hi {order.TouristName},\n" +
                    $"We confirm your booking for {order.Tour.TourName} at {order.Tour.Provider.ProviderName} has been canceled\n" +
                    $"You don't have to do anything else.";

                _emailService.SendEmail("ngoluuquocdat@gmail.com", subject, content, qrCodeAttachment: null);

                return order.Id;
            }
            else
            {
                return 0;
            }
        }
       

        public async Task<OrderPaymentInfoVm> GetOrderPaymentInfoAsync(int orderId)
        {
            var paymentInfo = await _context.Orders.Where(o => o.Id == orderId).AsNoTracking()
                                    .Select(o => new OrderPaymentInfoVm()
                                    {
                                        OrderId = o.Id,
                                        TourName = o.Tour.TourName,
                                        ProviderName = o.Tour.Provider.ProviderName,
                                        TotalPrice = o.Adults * o.Tour.PricePerAdult + o.Children * o.Tour.PricePerChild
                                    })
                                    .FirstOrDefaultAsync();

            return paymentInfo;
        }  

        public async Task<string> GetPaypalAcessTokenAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var authenticationString = $"{_configuration["Paypal:ClientId"]}:{_configuration["Paypal:SecretKey"]}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");
            //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");

            var response = await httpClient.PostAsync("https://api.sandbox.paypal.com/v1/oauth2/token?grant_type=client_credentials", 
                                                       new StringContent("{}", Encoding.UTF8, "application/x-www-form-urlencoded"));

            if (response.IsSuccessStatusCode)
            {
                var result_json = await response.Content.ReadAsStringAsync();
                JObject myDeserializedObj = JObject.Parse(result_json);
                return myDeserializedObj["access_token"].ToString();
            }
            return null;
        }
        public async Task<bool> CheckOrderTransactionId(int orderId, string transactionId, string access_token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");

            var response = await httpClient.GetAsync($"https://api.sandbox.paypal.com/v2/payments/captures/{transactionId}");

            if (response.IsSuccessStatusCode)
            {
                var result_json = await response.Content.ReadAsStringAsync();
                JObject myDeserializedObj = JObject.Parse(result_json);
                if (orderId == Int32.Parse(myDeserializedObj["invoice_id"].ToString()))
                {
                    return true;
                } 
            }
            return false;
        } 
        public async Task<bool> RefundTransaction(string transactionId, string access_token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");

            var response = await httpClient.PostAsync($"https://api.sandbox.paypal.com/v2/payments/captures/{transactionId}/refund",
                                                      new StringContent("{}", Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public void SendConfirmationEmail(Database.Entities.Order order)
        {
            var departure = order.DepartureDate.ToString("dd/MM/yyyy");
            var tourName = order.Tour.TourName.ToUpper();
            var tourStartTime = order.Tour.StartTime;
            var touristName = order.TouristName;
            var tourProvider = order.Tour.Provider.ProviderName;
            var tourProviderPhone = order.Tour.Provider.ProviderPhone;
            var tourProviderEmail = order.Tour.Provider.ProviderEmail;
            var tourProviderAddress = order.Tour.Provider.Address;

            var startPoint = order.StartPoint;
            var isStartCustomerChoice = startPoint.Split('&')[0].Equals("CustomerPoint");
            if (isStartCustomerChoice)
            {
                startPoint = $"your chosen place: {startPoint.Split('&')[1]} in {startPoint.Split('&')[2]}";
            }

            var endPoint = order.EndPoint;
            var isEndCustomerChoice = endPoint.Split('&')[0].Equals("CustomerPoint");
            if (isEndCustomerChoice)
            {
                endPoint = $"your chosen place: {endPoint.Split('&')[1]} in {endPoint.Split('&')[2]}";
            }

            // create QR code
            string qrText = $"OrderId: {order.Id}\n" +
                            $"Tour Provider: {tourProvider}\n" +
                            $"Tourist: {touristName}\n" +
                            $"Tour name: {tourName}\n" +
                            $"Depature: {departure}\n" +
                            $"Adults: {order.Adults}\n" +
                            $"Children: {order.Children}\n";

            byte[] qrCodeAsBytes = QRCodeService.CreateQRCodeAsBytes(qrText);

            // send email               
            string subject = $"You’re booked! Pack your bags – see you on {departure}!";
            string content = "<html>" +
                                "<body> " +
                                    $"<p> Hi {touristName}, </p> " +
                                    $"<p> Your booking for {tourName} at {tourProvider} is confirmed!</p> " +
                                    $"<p> {tourProvider} will see you on {order.DepartureDate.ToString("dd/MM/yyyy")}, at {startPoint}.<br>" +
                                    $"The starting time is {tourStartTime}, you should come earlier for preparation.<br>" +
                                    $"At the end of the tour, you will be taken to {endPoint}.</p>" +

                                    $"<p> All of your tour booking information is stored in the QR code attached below. <br>" +
                                    $"You don't need to print this email for confirmation at {tourProvider}. </p>" +
                                    $"<p> If you need to get in touch, you can contact your tour provider directly:<br>" +
                                    $"{tourProvider} <br>" +
                                    $"Phone: {tourProviderPhone} <br>" +
                                    $"Email: {tourProviderEmail} <br>" +
                                    $"Address: {tourProviderAddress} <br> <p/>" +
                                    $"<p> Thank you for booking tour on Happy Vacation. <p/>" +
                                    $"<p> Happy Vacation team. <p/>" +
                                "</body>" +
                             "</html>";
            _emailService.SendEmail("ngoluuquocdat@gmail.com", subject, content, qrCodeAttachment: qrCodeAsBytes);
        }

        public async Task FireNotificationAsync(int providerId)
        {
            // fire new notification 
            //var providerId = await _context.Tours.Where(x => x.Id == request.TourId).Select(x => x.ProviderId).FirstOrDefaultAsync();

            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("private_firebase_admin_key.json")

                });
            }

            // The topic name can be optionally prefixed with "/topics/".
            var topic = $"Tour_Provider_{providerId}";

            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "type", "tour" },
                    { "provider", providerId.ToString() }
                },
                Topic = topic,
                Notification = new Notification()
                {
                    Title = "New tour order",
                    Body = "You have a new pending order"
                }
            };

            // Send a message to the devices subscribed to the provided topic.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }

        public async Task<int> ChangeDepartureDate(int userId, int orderId, string newDate)
        {
            var NOT_FOUND_ERROR = -1;
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            var order = await _context.Orders.Include(x => x.Tour).ThenInclude(t => t.Provider).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == orderId && x.Tour.ProviderId == providerId);
            // check if provider has this order
            if (order == null)
            {
                return NOT_FOUND_ERROR;
            }

            order.DepartureDate = DateTime.ParseExact(newDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<OrderedTouristCollect> GetOrderedTouristCollection(int userId, int tourId, string departureDateStr)
        {
            var depatureDate = DateTime.ParseExact(departureDateStr, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            var tour = await _context.Tours.Where(x => x.Id == tourId && x.ProviderId == providerId)
                                           .Select(x => new
                                           { 
                                               Id = x.Id,
                                               TourName = x.TourName
                                           }).FirstOrDefaultAsync();
            // check if provider has this tour
            if (tour == null)
            {
                return null;
            }

            // get ordered tourist collection
            var orderedTouristCollect = new OrderedTouristCollect()
            {
                TourId = tour.Id,
                TourName = tour.TourName,
                DepartureDate = departureDateStr
            };

            // get orders by tour id and depature date
            orderedTouristCollect.TouristGroups = await _context.Orders.Where(x => x.TourId == tourId && x.DepartureDate.Date == depatureDate.Date)
                                        .AsNoTracking()
                                        //.Skip(1)
                                        //.Take(2)
                                        .Select(x => new OrderedTourists
                                        {
                                            OrderId = x.Id,
                                            StartPoint = x.StartPoint,
                                            EndPoint = x.EndPoint,
                                            AdultsList = x.OrderMembers.Where(om => om.IsChild == false).Select(om => new AdultVm()
                                            {
                                                IdentityNumber = om.IdentityNum,
                                                FullName = om.FullName,
                                                Dob = om.DateOfBirth.ToString("dd/MM/yyyy")
                                            }),
                                            ChildrenList = x.OrderMembers.Where(om => om.IsChild == true).Select(om => new ChildVm()
                                            {
                                                IdentityNumber = om.IdentityNum,
                                                FullName = om.FullName,
                                                Dob = om.DateOfBirth.ToString("dd/MM/yyyy")
                                            }),
                                        }).ToListAsync();

            orderedTouristCollect.TotalCount = orderedTouristCollect.TouristGroups.Sum(item => item.AdultsList.Count() + item.ChildrenList.Count());

            // create report file
            var exportFileName = $"Tourists_Tour{tourId}_{departureDateStr}";
            orderedTouristCollect.ExportFilePath = await _xlsxService.ExportOrderedTouristCollection((int)providerId, exportFileName, orderedTouristCollect);

            return orderedTouristCollect;
        }
    }
}
