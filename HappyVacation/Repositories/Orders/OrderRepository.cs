using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using HappyVacation.Database;
using HappyVacation.Database.Entities;
using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Orders;
using HappyVacation.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HappyVacation.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;

        public OrderRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(int userId, CreateTourOrderRequest request)
        {
            var order = new Order()
            {
                UserId = userId,
                TourId = request.TourId,
                DepartureDate = DateTime.Parse(request.DepartureDate),
                Adults = request.Adults,
                Children = request.Children,
                TouristName = request.TouristName,
                TouristPhone = request.TouristPhone,
                TouristEmail = request.TouristEmail,
                OrderDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                State = "pending"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

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

        public async Task<OrderManageInfoVm> GetOrderById(int orderId)
        {
            var query = _context.Orders.Where(x => x.Id == orderId).AsNoTracking();

            var order = await query.Select(x => new OrderManageInfoVm()
            {
                Id = x.Id,
                TourId = x.TourId,
                TourName = x.Tour.TourName,
                DepartureDate = x.DepartureDate.ToString("dd/MM/yyyy"),
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
                TouristEmail = x.TouristEmail
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
                TouristEmail = x.TouristEmail
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
                DepartureDate = x.DepartureDate.ToShortDateString(),
                ModifiedDate = x.ModifiedDate.ToShortDateString(),
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
                ProviderName = x.Tour.Provider.ProviderName
            }).ToListAsync();

            return new PagedResult<OrderMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = orders
            };
        }

        public async Task<int> ChangeOrderState(int userId, int orderId, string state)
        {       
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId && x.Tour.ProviderId == providerId);
            // check if provider has this order
            if(order == null)
            {
                return -1;
            }
            // change order state
            if(!order.State.Equals(state))
            {
                order.State = state;
                order.ModifiedDate = DateTime.Now;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                return order.Id;
            } else
            {
                return 0;
            }
        }
    }
}
