using HappyVacation.Database;
using HappyVacation.Database.Entities;
using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Orders;
using HappyVacation.DTOs.Places;
using HappyVacation.DTOs.Providers;
using HappyVacation.DTOs.Providers.ProviderManage;
using HappyVacation.DTOs.Tours;
using HappyVacation.Services.Storage;
using HappyVacation.Services.XLSX;
using HappyVacation.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HappyVacation.Repositories.Providers
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly MyDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IXLSXService _xlsxService;

        public ProviderRepository(MyDbContext context, IStorageService storageService, IXLSXService xlsxService)
        {
            _context = context;
            _storageService = storageService;
            _xlsxService = xlsxService;
        }


        public async Task<ProviderVm> GetProviderById(int providerId)
        {
            if (!_context.Providers.Any(x => (x.Id == providerId)))
            {
                return null;
            }

            var provider = await _context.Providers.Where(x => x.Id == providerId).AsNoTracking()
                                            .Select(x => new ProviderVm()
                                            {
                                                Id = x.Id,
                                                Name = x.ProviderName,
                                                Address = x.Address,
                                                Phone = x.ProviderPhone,
                                                Email = x.ProviderEmail,
                                                AvatarUrl = x.AvatarUrl,
                                                DateCreated = x.DateCreated.ToString("dd/MM/yyyy"),
                                                Description = x.Description,
                                                TourAvailable = x.Tours.Where(x => x.IsAvailable == true).Count(),
                                                IsEnable = x.IsEnabled
                                            }).FirstOrDefaultAsync();

            if(!_context.Tours.Any(x => x.ProviderId == providerId))
            {
                provider.AverageRating = 0;
            } 
            else
            {
                provider.AverageRating = (float)Math.Round(
                                            (_context.Tours.Where(x => x.ProviderId == providerId)
                                            .Select(x => (x.Reviews.Count() != 0) ? x.Reviews.Average(r => r.Rating) : -1)
                                            .ToList())
                                            .Where(x => x != -1)                                
                                            .Average(), 2);
            }

            return provider;
        }

        public async Task<ProviderProfileVm> GetProviderProfile(int userId)
        {
            if (!_context.Providers.Any(x => (x.User.Id == userId)))
            {
                return null;
            }

            var provider = await _context.Providers.Where(x => x.User.Id == userId).AsNoTracking()
                                            .Select(x => new ProviderProfileVm()
                                            {
                                                Id = x.Id,
                                                Name = x.ProviderName,
                                                Address = x.Address,
                                                Phone = x.ProviderPhone,
                                                Email = x.ProviderEmail,
                                                AvatarUrl = x.AvatarUrl,
                                                Description = x.Description,
                                                IsEnable = x.IsEnabled
                                            }).FirstOrDefaultAsync();
            return provider;
        }

        public async Task<PagedResult<TourMainInfoVm>> GetTours(int providerId, string? sort, int page, int perPage)
        {
            if (!_context.Providers.Any(x => (x.Id == providerId)))
            {
                return null;
            }

            var query = _context.Tours.Where(x => (x.ProviderId == providerId) && (x.IsAvailable == true));           

            // 1. sorting
            if (!String.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "latest":
                        query = query.OrderByDescending(x => x.Id); // should be 'Date Created';
                        break;
                    case "price-up":
                        query = query.OrderBy(x => x.PricePerAdult * x.MinAdults).ThenByDescending(x => x.Id); ;
                        break;
                    case "price-down":
                        query = query.OrderByDescending(x => x.PricePerAdult * x.MinAdults).ThenByDescending(x => x.Id);
                        break;
                    case "rating":
                        query = query.OrderByDescending(x => (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Average(r => r.Rating), 2) : 0).ThenByDescending(x => x.Id);
                        break;
                    case "orders":
                        query = query.OrderByDescending(x => x.Orders.Where(o => o.State == "confirmed").Count()).ThenByDescending(x => x.Id);
                        break;
                }
            }

            // 2. paging
            // default values
            page = page == 0 ? 1 : page;
            perPage = perPage == 0 ? 10 : perPage;
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / perPage) + 1;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            var tours = await query.Select(x => new TourMainInfoVm()
            {
                Id = x.Id,
                TourName = x.TourName,
                Reviews = x.Reviews.Count(),
                Rating = (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 2) : 0,
                IsPrivate = x.IsPrivate,
                Duration = x.Duration,
                MinPrice = x.PricePerAdult * x.MinAdults,
                ThumbnailPath = (x.TourImages.Count() > 0) ? x.TourImages[0].Url : String.Empty
            }).AsSplitQuery().ToListAsync();

            return new PagedResult<TourMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = tours
            };
        }

        public async Task<PagedResult<TourMainInfoManageVm>> GetToursManage(int userId, GetTourManageRequest request)
        {
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            if (providerId == null || providerId == 0)
            {
                return null;
            }
            // get tours
            var query = _context.Tours.Where(x => (x.ProviderId == providerId));

            // 1. filtering
            // by tour id:
            if(request.TourId != 0)
            {
                query = query.Where(x => x.Id == request.TourId);
            }

            // by tour name:
            if (!String.IsNullOrEmpty(request.TourName))
            {
                query = query.Where(x => x.TourName.ToLower().Contains(request.TourName.ToLower()));
            }

            // by places:
            if (request.PlaceIds != null && request.PlaceIds.Count() > 0)
            {
                foreach (var placeId in request.PlaceIds)
                {
                    query = query.Where(x => x.TourPlaces.Any(tp => tp.PlaceId == placeId));
                }
            }

            // by categories:
            if (request.CategoryIds != null && request.CategoryIds.Count() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    query = query.Where(x => x.TourCategories.Any(tc => tc.CategoryId == categoryId));
                }
            }

            // 2. sorting
            if (!String.IsNullOrEmpty(request.Sort))
            {
                switch (request.Sort)
                {
                    case "latest":
                        query = query.OrderByDescending(x => x.Id); // should be 'Date Created';
                        break;
                    case "price-up":
                        query = query.OrderBy(x => x.PricePerAdult * x.MinAdults).ThenByDescending(x => x.Id);
                        break;
                    case "price-down":
                        query = query.OrderByDescending(x => x.PricePerAdult * x.MinAdults).ThenByDescending(x => x.Id);
                        break;
                    case "rating-up":
                        query = query.OrderBy(x => (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 1) : 0).ThenByDescending(x => x.Id);
                        break;
                    case "rating-down":
                        query = query.OrderByDescending(x => (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 1) : 0).ThenByDescending(x => x.Id);
                        break;
                    case "orders-up":
                        query = query.OrderBy(x => x.Orders.Where(o => o.State == "confirmed").Count()).ThenByDescending(x => x.Id);
                        break;
                    case "orders-down":
                        query = query.OrderByDescending(x => x.Orders.Where(o => o.State == "confirmed").Count()).ThenByDescending(x => x.Id);
                        break;
                }
            }

            // 3. paging
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / request.PerPage) + 1;
            query = query.Skip((request.Page - 1) * request.PerPage).Take(request.PerPage);

            var tours = await query.Select(x => new TourMainInfoManageVm()
            {
                Id = x.Id,
                TourName = x.TourName,
                IsPrivate = x.IsPrivate,
                Duration = x.Duration,
                PricePerAdult = x.PricePerAdult,
                PricePerChild = x.PricePerChild,
                GroupSize = x.GroupSize,
                ThumbnailPath = (x.TourImages.Count() > 0) ? x.TourImages[0].Url : String.Empty,
                Places = x.TourPlaces.Select(tp => new PlaceVm()
                {
                    Id = tp.PlaceId,
                    PlaceName = tp.Place.PlaceName
                }),
                Categories = x.TourCategories.Select(tc => new CategoryVm()
                {
                    Id = tc.CategoryId,
                    CategoryName = tc.Category.CategoryName
                }),
                Reviews = x.Reviews.Count(),
                Rating = (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 1) : 0,
                OrderCount = x.Orders.Where(o => o.State == "confirmed").Count(),
                IsAvailable = x.IsAvailable
            }).AsSplitQuery().ToListAsync();

            return new PagedResult<TourMainInfoManageVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = tours
            };
        }

        public async Task<bool?> UpdateProvider(int userId, UpdateProviderRequest request)
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(x => x.User.Id == userId);
            if (provider == null)
            {
                return null;
            }
            provider.ProviderName = request.Name;
            provider.Description = request.Description;
            provider.ProviderPhone = request.Phone;
            provider.ProviderEmail = request.Email;
            provider.Address = request.Address;

            // save new avatar 
            if (request.Avatar != null)
            {
                provider.AvatarUrl = await _storageService.SaveImage(request.Avatar);
            }

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<string> GetOrderExport(int userId, string startDate, string endDate)
        {
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            if (providerId == null || providerId == 0)
            {
                return "Forbid";
            }
            var _startDate = DateTime.Parse(startDate);
            var _endDate = DateTime.Parse(endDate);
            // get orders
            var orders = await _context.Orders
                                    .Where(x => (x.Tour.ProviderId == providerId) &&
                                    (x.OrderDate.Date >= _startDate) && (x.OrderDate.Date <= _endDate) &&
                                    (x.State != "pending"))
                                    .AsNoTracking().Select(x => new OrderManageInfoVm()
                                    {
                                        Id = x.Id,
                                        TourId = x.TourId,
                                        TourName = x.Tour.TourName,
                                        DepartureDate = x.DepartureDate.ToString("dd/MM/yyyy"),
                                        OrderDate = x.OrderDate.ToString("dd/MM/yyyy"),
                                        ModifiedDate = x.ModifiedDate.ToString("dd/MM/yyyy"),
                                        //Duration = x.Tour.Duration,
                                        //IsPrivate = x.Tour.IsPrivate,
                                        Adults = x.Adults,
                                        Children = x.Children,
                                        PricePerAdult = x.Tour.PricePerAdult,
                                        PricePerChild = x.Tour.PricePerChild,
                                        TotalPrice = x.Adults * x.Tour.PricePerAdult + x.Children * x.Tour.PricePerChild,
                                        //ThumbnailUrl = (x.Tour.TourImages.Count() > 0) ? x.Tour.TourImages[0].Url : String.Empty,
                                        State = x.State,
                                        TouristName = x.TouristName,
                                        TouristPhone = x.TouristPhone,
                                        TouristEmail = x.TouristEmail
                                    }).ToListAsync();
            // create report file
            var exportFileName = $"Orders.{startDate}_{endDate}";
            var exportFilePath = await _xlsxService.ExportTourOrder((int)providerId, exportFileName, orders);
            

            return exportFilePath;
        }

        public async Task<List<TourSimpleVm>> GetSimplifiedTours(int userId)
        {
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            if (providerId == null || providerId == 0)
            {
                return null;
            }
            // get tours
            var query = _context.Tours.Where(x => (x.ProviderId == providerId));

            var tours = await query.Select(x => new TourSimpleVm()
            {
                Id = x.Id,
                TourName = x.TourName
            }).ToListAsync();

            return tours;
        }

        public async Task<int> CreateProviderRegistration(int userId, ProviderRegistrationRequest request)
        {
            var registration = new ProviderRegistration()
            {
                UserId = userId,
                ProviderName = request.ProviderName,
                ContactPersonName = request.ContactPersonName,
                ProviderEmail = request.ProviderEmail,
                ProviderPhone = request.ProviderPhone,
                DateCreated = DateTime.Now,
                IsApproved = false
            };

            _context.ProviderRegistrations.Add(registration);
            await _context.SaveChangesAsync();

            //return tour.Id;
            return registration.Id;
        }

        public async Task<ProviderRegistrationVm> GetProviderRegistration(int userId)
        {
            var result = await _context.ProviderRegistrations.Where(x => x.UserId == userId).AsNoTracking()
                                       .Select(x => new ProviderRegistrationVm()
                                       {
                                           Id = x.Id,
                                           ProviderName = x.ProviderName,
                                           ContactPersonName = x.ContactPersonName,
                                           ProviderEmail = x.ProviderEmail,
                                           ProviderPhone = x.ProviderPhone,
                                           DateCreated = x.DateCreated.ToString("dd/MM/yyyy"),
                                           IsApproved = x.IsApproved
                                       })
                                       .FirstOrDefaultAsync();

            return result;
        }

        public async Task<ProviderRegistrationVm> GetProviderRegistrationById(int registrationId)
        {
            var result = await _context.ProviderRegistrations.Where(x => x.Id == registrationId).AsNoTracking()
                                       .Select(x => new ProviderRegistrationVm()
                                       {
                                           Id = x.Id,
                                           ProviderName = x.ProviderName,
                                           ContactPersonName = x.ContactPersonName,
                                           ProviderEmail = x.ProviderEmail,
                                           ProviderPhone = x.ProviderPhone,
                                           DateCreated = x.DateCreated.ToString("dd/MM/yyyy"),
                                           IsApproved = x.IsApproved
                                       })
                                       .FirstOrDefaultAsync();

            return result;
        }

        public async Task<PagedResult<ProviderRegistrationVm>> GetRegistrations(GetProviderRegistrationRequest request)
        {
            var query = _context.ProviderRegistrations.AsNoTracking();

            // fitler
            // by Id
            if (request.RegistrationId != 0)
            {
                query = query.Where(x => x.Id == request.RegistrationId);
            }
            // by provider name
            if (!String.IsNullOrEmpty(request.ProviderName))
            {
                query = query.Where(x => x.ProviderName.Contains(request.ProviderName));
            }
            // by contact person name
            if (!String.IsNullOrEmpty(request.ContactPersonName))
            {
                query = query.Where(x => x.ContactPersonName.Contains(request.ContactPersonName));
            }
            // by provider email
            if (!String.IsNullOrEmpty(request.ProviderEmail))
            {
                query = query.Where(x => x.ProviderEmail.Contains(request.ProviderEmail));
            }
            // by provider phone
            if (!String.IsNullOrEmpty(request.ProviderPhone))
            {
                query = query.Where(x => x.ProviderPhone.Contains(request.ProviderPhone));
            }

            // sort by date created
            query = query.OrderByDescending(x => x.DateCreated);

            // paging
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / request.PerPage) + 1;
            query = query.Skip((request.Page - 1) * request.PerPage).Take(request.PerPage);

            var registrations = await query.Select(x => new ProviderRegistrationVm()
            {
                Id = x.Id,
                UserId = x.UserId,
                ProviderName = x.ProviderName,
                ContactPersonName = x.ContactPersonName, 
                ProviderEmail = x.ProviderEmail,
                ProviderPhone = x.ProviderPhone,
                DateCreated = x.DateCreated.ToString("dd/MM/yyyy"),
                IsApproved = x.IsApproved
            }).ToListAsync();

            return new PagedResult<ProviderRegistrationVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = registrations
            };
        }

        public async Task<int> ApproveProviderRegistration(int registrationId)
        {
            var NOT_FOUND_ERROR = -1;


            var registration = await _context.ProviderRegistrations.FirstOrDefaultAsync(x => x.Id == registrationId);
            if(registration == null)
            {
                return NOT_FOUND_ERROR;
            }

            if(registration.IsApproved == false)
            {
                registration.IsApproved = true;

                // add "Provider" role to the user
                _context.UserRoles.Add(new UserRole() { UserId = registration.UserId, RoleId = 2 });
                
                // create new provider with default information
                var newProvider = new Provider()
                {
                    ProviderName = registration.ProviderName,
                    Description = "_Please update this information_",
                    ProviderEmail = registration.ProviderEmail,
                    ProviderPhone = registration.ProviderPhone,
                    Address = "_Please update this information_",
                    AvatarUrl = "/storage/default-provider-avatar.png",
                    DateCreated = DateTime.Now,
                    IsEnabled = true               
                };
                _context.Providers.Add(newProvider);

                // associate new provider to the user
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == registration.UserId);
                user.Provider = newProvider;

                await _context.SaveChangesAsync();

                return registration.Id;
            }
            else
            {
                return 0;
            }           
        }
        public async Task<int> DisableProvider(int providerId)
        {
            var provider = await _context.Providers.Where(x => x.Id == providerId).FirstOrDefaultAsync();
            if (provider == null)
            {
                return 0;
            }

            provider.IsEnabled = false;
            await _context.SaveChangesAsync();

            return provider.Id;
        }

        public async Task<int> EnableProvider(int providerId)
        {
            var provider = await _context.Providers.Where(x => x.Id == providerId).FirstOrDefaultAsync();
            if (provider == null)
            {
                return 0;
            }

            provider.IsEnabled = true;
            await _context.SaveChangesAsync();

            return provider.Id;
        }

        public async Task<PagedResult<ProviderManageMainInfoVm>> GetProvidersManage(GetProvidersManageRequest request)
        {
            var query = _context.Providers.AsNoTracking();

            // filter by Id
            if(request.ProviderId != 0)
            {
                query = query.Where(x => x.Id == request.ProviderId);
            }
            // filter by owner Id
            if(request.OwnerId != 0)
            {
                query = query.Where(x => x.User.Id == request.OwnerId);
            }
            // filter by keyword provider info
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                var phoneRegex = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
                // by phone
                if (phoneRegex.IsMatch(request.Keyword))
                {
                    query = query.Where(x => (x.ProviderName.Contains(request.Keyword)));
                }
                // by email
                if (EmailValid.IsValid(request.Keyword))
                {
                    query = query.Where(x => (x.ProviderEmail.Contains(request.Keyword)));
                }
                // by name
                if (!EmailValid.IsValid(request.Keyword) && !phoneRegex.IsMatch(request.Keyword))
                {
                    query = query.Where(x => (x.ProviderName.Contains(request.Keyword)));
                }
            }

            // order by modified date
            query = query.OrderByDescending(x => x.DateCreated);

            // paging
            // 3. paging
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / request.PerPage) + 1;
            query = query.Skip((request.Page - 1) * request.PerPage).Take(request.PerPage);

            var providers = await query.Select(x => new ProviderManageMainInfoVm()
            {
                Id = x.Id,
                ProviderName = x.ProviderName,
                AvatarUrl = x.AvatarUrl,
                DateCreated = x.DateCreated.ToString("dd/MM/yyyy"),
                IsEnabled = x.IsEnabled,
                UserId = x.User.Id       
            }).ToListAsync();

            // calculate average ratings
            for(int i=0; i<providers.Count; i++)
            {
                if (!_context.Tours.Any(x => x.ProviderId == providers[i].Id))
                {
                    providers[i].AverageRating = 0;
                }
                else
                {
                    providers[i].AverageRating = (float)Math.Round(
                                                (
                                                    _context.Tours.Where(x => x.ProviderId == providers[i].Id)
                                                        .Select(x => (x.Reviews.Count() != 0) ? x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating) : -1)
                                                        .ToList()
                                                )
                                                .Where(x => x != -1)
                                                .Average(), 2);
                }
            }

            return new PagedResult<ProviderManageMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = providers
            };
        }

        public async Task<ProviderManageDetailVm> GetProviderDetailManage(int providerId)
        {
            if (!_context.Providers.Any(x => (x.Id == providerId)))
            {
                return null;
            }

            var provider = await _context.Providers.Where(x => x.Id == providerId).AsNoTracking()
                                        .Select(x => new ProviderManageDetailVm()
                                        {
                                            Id = x.Id,
                                            ProviderName = x.ProviderName,
                                            ProviderPhone = x.ProviderPhone,
                                            ProviderEmail = x.ProviderEmail,
                                            AvatarUrl = x.AvatarUrl,
                                            Address = x.Address,
                                            DateCreated = x.DateCreated.ToString("dd/MM/yyyy"),
                                            Description = x.Description,
                                            OwnerUsername = x.User.Username,
                                            OwnerFullName = $"{x.User.FirstName} {x.User.LastName}",
                                            TotalTourCount = x.Tours.Count()
                                        }).FirstOrDefaultAsync();

            // calculate average rating
            if (!_context.Tours.Any(x => x.ProviderId == providerId))
            {
                provider.AverageRating = 0;
            }
            else
            {
                provider.AverageRating = (float)Math.Round(
                                            (_context.Tours.Where(x => x.ProviderId == providerId)
                                            .Select(x => (x.Reviews.Count() != 0) ? x.Reviews.Average(r => r.Rating) : -1)
                                            .ToList())
                                            .Where(x => x != -1)
                                            .Average(), 2);
            }
            // get orders count
            provider.TotalOrderCount = (await _context.Tours.Where(x => x.ProviderId == provider.Id).Select(x => x.Orders.Count()).ToListAsync()).Sum(el => el);
            provider.ConfirmedOrderCount = (await _context.Tours.Where(x => x.ProviderId == provider.Id).Select(x => x.Orders.Where(o => o.State == "confirmed").Count()).ToListAsync()).Sum(el => el);
            provider.CanceledOrderCount = (await _context.Tours.Where(x => x.ProviderId == provider.Id).Select(x => x.Orders.Where(o => o.State == "canceled").Count()).ToListAsync()).Sum(el => el);

            // get top categories
            provider.TopCategories = await GetTopCategories(provider.Id);

            return provider;
        }

        public async Task<List<string>> GetTopCategories(int providerId)
        {
            var query = from category in _context.Categories
                        join tourCategory in _context.TourCategories on category.Id equals tourCategory.CategoryId
                        join tour in _context.Tours on tourCategory.TourId equals tour.Id
                        where tour.ProviderId.Equals(providerId)
                        group category by category.Id into categoryGroup
                        orderby categoryGroup.Count() descending
                        
                        select new CategoryVm
                        {
                            Id = categoryGroup.Key,
                            CategoryName = categoryGroup.First().CategoryName,
                            Count = categoryGroup.Count()
                        };

            return await query.Select(x => x.CategoryName).Take(2).ToListAsync();
        }

        public async Task<PagedResult<TourMainInfoManageVm>> GetToursAdmin(int providerId, int page = 1, int perPage = 4)
        {
            var provider = await _context.Providers.Where(x => x.Id == providerId).FirstOrDefaultAsync();
            if (provider == null)
            {
                return null;
            }

            // get tours
            var query = _context.Tours.Where(x => (x.ProviderId == providerId));
            query = query.OrderByDescending(x => x.Id); // should be 'Date Created';                             

            // paging
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / perPage) + 1;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            var tours = await query.Select(x => new TourMainInfoManageVm()
            {
                Id = x.Id,
                TourName = x.TourName,
                Reviews = x.Reviews.Count(),
                Rating = (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 1) : 0,
                OrderCount = x.Orders.Where(o => o.State == "confirmed").Count(),
                IsAvailable = x.IsAvailable
            }).AsSplitQuery().ToListAsync();

            return new PagedResult<TourMainInfoManageVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = tours
            };
        }

        public async Task<RevenueVm> GetRevenueByQuarter(int quarterIndex, int year, int userId = 0, int providerId = 0)
        {
            //var _startDate = DateTime.Parse(startDate);
            //var _endDate = DateTime.Parse(endDate);

            // get months in quarter
            var months = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            months = months.Skip((quarterIndex - 1) * 3).Take(3).ToList();

            var _providerId = 0;
            if (userId != 0 && providerId == 0)
            {
                _providerId = (await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync()).GetValueOrDefault();
            }
            if (userId == 0 && providerId != 0)
            {
                _providerId = providerId;
            }

            var monthLabels = new List<string>();
            var listRevenue = new List<int>();

            foreach (var month in months)
            {
                monthLabels.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(month));

                listRevenue.Add(
                    _context.Orders.Where(x => x.Tour.ProviderId == _providerId &&
                                               x.State == "confirmed" &&
                                               x.OrderDate.Month == month &&
                                               x.OrderDate.Year == year
                                          ).Sum(x => x.Adults * x.Tour.PricePerAdult + x.Children * x.Tour.PricePerChild)
                );
            }

            return new RevenueVm()
            {
                MonthLabels = monthLabels,
                Revenue = listRevenue
            };
        }
    }
}
