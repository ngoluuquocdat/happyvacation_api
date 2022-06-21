using HappyVacation.Database;
using HappyVacation.Database.Entities;
using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Places;
using HappyVacation.DTOs.Reviews;
using HappyVacation.DTOs.Tours;
using HappyVacation.Services.Storage;
using Microsoft.EntityFrameworkCore;

namespace HappyVacation.Repositories.Tours
{
    public class TourRepository : ITourRepository
    {
        private readonly MyDbContext _context;
        private readonly IStorageService _storageService;

        public TourRepository(MyDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<PagedResult<TourMainInfoVm>> GetTours(GetTourRequest request)
        {
            var query = _context.Tours.Where(x => x.IsAvailable == true && x.Provider.IsEnabled == true);
            
            // 1. Filtering
            // by place Id
            if(request.PlaceId != 0)
            {
                query = query.Where(x => x.TourPlaces.Any(tp => tp.PlaceId == request.PlaceId));
            }
            // by duration
            if(request.Duration != 0)
            {
                query = query.Where(x => x.Duration <= request.Duration);
            }
            // by type
            if(request.PrivateOnly == true)
            {
                query = query.Where(x => x.IsPrivate == true);
            }
            // by keyword (tour name)
            if(!String.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.TourName.ToLower().Contains(request.Keyword.ToLower()));
            }
            // by price 
            if(request.MaxPrice != 0)
            {
                query = query.Where(x => (x.PricePerAdult * x.MinAdults >= request.MinPrice) && (x.PricePerAdult * x.MinAdults <= request.MaxPrice));
            }
            // by categories
            if(request.CategoryIds!=null && request.CategoryIds.Count() > 0)
            {
                if(request.MatchAll == true)
                {
                    foreach(var categoryId in request.CategoryIds)
                    {
                        query = query.Where(x => x.TourCategories.Any(tc => tc.CategoryId == categoryId));
                    }
                    //query = query.Where(x => x.TourCategories.All(tc => request.CategoryIds.Contains(tc.CategoryId)));
                } 
                else
                {
                    query = query.Where(x => x.TourCategories.Any(tc => request.CategoryIds.Contains(tc.CategoryId)));
                }
            }

            // 2. sorting
            if(!String.IsNullOrEmpty(request.Sort))
            {
                switch(request.Sort)
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
                    case "rating":
                        query = query.OrderByDescending(x => (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 1) : 0).ThenByDescending(x => x.Id);
                        break;
                    case "orders":
                        query = query.OrderByDescending(x => x.Orders.Where(o => o.State == "confirmed").Count()).ThenByDescending(x => x.Id);
                        break;
                }
            }

            // 3. paging
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / request.PerPage) + 1;
            query = query.Skip((request.Page - 1) * request.PerPage).Take(request.PerPage);

            var tours = await query.Select(x => new TourMainInfoVm()
            {
                Id = x.Id,
                TourName = x.TourName,
                Reviews = x.Reviews.Count(),
                Rating = (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 1) : 0,
                IsPrivate = x.IsPrivate,
                Duration = x.Duration,
                MinPrice = x.PricePerAdult * x.MinAdults,
                ThumbnailPath = (x.TourImages.Count()>0) ? x.TourImages[0].Url : String.Empty
            }).ToListAsync();

            return new PagedResult<TourMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = tours
            };
        }       

        public async Task<TourVm> GetTourById(int tourId, int userId = 0)
        {
            if (!_context.Tours.Any(x => (x.Id == tourId)))
            {
                return null;
            }

            // check if tour in user's wish list
            // var inWishList = _context.WishItems.Any(x => x.TourId == tourId && x.UserId == userId);

            var tour = await _context.Tours
                                   .Where(x => x.Id == tourId)                                 
                                   .Select(x => new TourVm()
                                   {
                                       Id = x.Id,
                                       TourName = x.TourName,
                                       Overview = x.Overview,
                                       Duration = x.Duration,
                                       IsPrivate = x.IsPrivate,
                                       GroupSize = x.GroupSize,
                                       MinAdults = x.MinAdults,
                                       PricePerAdult = x.PricePerAdult,
                                       PricePerChild = x.PricePerChild,
                                       StartTime = x.StartTime,
                                       StartPoint = x.StartPoint,
                                       EndPoint = x.EndPoint,
                                       Reviews = x.Reviews.Count(),
                                       Rating = (x.Reviews.Count() != 0) ?
                                       (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 1) : 0,
                                       ProviderId = x.ProviderId,
                                       ProviderName = x.Provider.ProviderName,
                                       ProviderAvatar = x.Provider.AvatarUrl,
                                       IsProviderEnabled = x.Provider.IsEnabled,
                                       Itineraries = x.Itineraries.Select(i => new ItineraryVm()
                                       {
                                           Id = i.Id,
                                           Title = i.Title,
                                           Content = i.Content
                                       }),
                                       Expenses = x.Expenses.Select(e => new ExpenseVm()
                                       {
                                           Id = e.Id,
                                           Content = e.Content,
                                           IsIncluded = e.IsIncluded
                                       }),
                                       Images = x.TourImages.Select(img => new ImageVm()
                                       {
                                           Id = img.Id,
                                           Url = img.Url
                                       }),
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
                                       IsInUserWishList = userId != 0 ? x.WishItems.Any(wishItem => wishItem.UserId == userId) : false,
                                       IsOrderedByUser = userId != 0 ? x.Orders.Any(order => order.UserId == userId && 
                                                                               order.State == "confirmed" && 
                                                                               order.DepartureDate.Date < DateTime.Now.Date) : false
                                   }).FirstOrDefaultAsync();

            return tour;
        }
        // tour management for provider
        public async Task<TourMainInfoManageVm> GetTourByIdManage(int tourId)
        {
            if (!_context.Tours.Any(x => (x.Id == tourId)))
            {
                return null;
            }

            var tour = await _context.Tours
                                   .Where(x => x.Id == tourId)
                                   .Select(x => new TourMainInfoManageVm()
                                   {
                                       Id = x.Id,
                                       TourName = x.TourName,
                                       Duration = x.Duration,
                                       IsPrivate = x.IsPrivate,
                                       GroupSize = x.GroupSize,
                                       PricePerAdult = x.PricePerAdult,
                                       PricePerChild = x.PricePerChild,
                                       Reviews = x.Reviews.Count(),
                                       Rating = (x.Reviews.Count() != 0) ?
                                       (float)Math.Round(x.Reviews.Where(r => r.Rating != 0).Average(r => r.Rating), 1) : 0,
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
                                       ThumbnailPath = (x.TourImages.Count() > 0) ? x.TourImages[0].Url : String.Empty,
                                       IsAvailable = x.IsAvailable,
                                       OrderCount = x.Orders.Count()
                                   }).AsSplitQuery().FirstOrDefaultAsync();

            return tour;
        }
        public async Task<int> Create(int userId, CreateTourRequest request)
        {
            // get provider Id
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();

            // check if provider exists
            if (providerId == null || providerId == 0)
            {
                return -1;
            }

            // tour's main info
            Tour tour = new Tour()
            {
                TourName = request.TourName,
                Overview = request.Overview,
                Duration = request.Duration,
                GroupSize = request.GroupSize,
                MinAdults = request.MinAdults,
                StartTime = request.StartTime,
                StartPoint = request.StartPoint,    
                EndPoint = request.EndPoint,
                PricePerAdult = request.PricePerAdult,
                PricePerChild = request.IncludeChildren ? request.PricePerChild : -1,
                ProviderId = (int)providerId,
                IsAvailable = true
            };
            // places
            var tourPlaces = new List<TourPlace>();
            foreach (var placeId in request.PlaceIds)
            {
                tourPlaces.Add(new TourPlace()
                {
                    PlaceId = placeId
                });
            }
            // categories
            var tourCategories = new List<TourCategory>();
            foreach (var categoryId in request.CategoryIds)
            {
                tourCategories.Add(new TourCategory()
                {
                    CategoryId = categoryId
                });
            }
            // itineraries
            var itineraries = new List<Itinerary>();
            foreach (var itinerary in request.Itineraries)
            {
                itineraries.Add(new Itinerary()
                {
                    Title = itinerary.Title,
                    Content = itinerary.Content,
                });
            }
            // expenses
            var expenses = new List<Expense>();
            foreach(var expense in request.Expenses)
            {
                expenses.Add(new Expense()
                {
                    Content = expense.Content,
                    IsIncluded = expense.IsIncluded
                });
            }
            // images
            var images = new List<TourImage>();
            foreach (var image in request.Images)
            {
                images.Add(new TourImage()
                {
                    Url = await _storageService.SaveImage(image)
                });
            }

            tour.TourPlaces = tourPlaces;
            tour.TourCategories = tourCategories;
            tour.Itineraries = itineraries;
            tour.Expenses = expenses;
            tour.TourImages = images;

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            return tour.Id;
        }
        public async Task<int> ChangeTourProvidingState(int userId, int tourId)
        {
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            var tour = await _context.Tours.FirstOrDefaultAsync(x => x.Id == tourId && x.ProviderId == providerId);
            // check if provider has this tour
            if (tour == null)
            {
                return -1;
            }
            // change tour providing state
            tour.IsAvailable = !tour.IsAvailable;
            await _context.SaveChangesAsync();

            return tour.Id;
        }
        public async Task<int> UpdateTour(int userId, int tourId, UpdateTourRequest request)
        {
            var providerId = await _context.Users.Where(x => x.Id == userId).AsNoTracking().Select(x => x.ProviderId).FirstOrDefaultAsync();
            var tour = await _context.Tours.Include(x => x.TourPlaces)
                                            .Include(x => x.TourCategories)
                                            //.Include(x => x.TourImages)
                                            .Include(x => x.Itineraries)
                                            .Include(x => x.Expenses)
                                            .FirstOrDefaultAsync(x => x.Id == tourId && x.ProviderId == providerId);
            // check if provider has this tour
            if (tour == null)
            {
                return -1;
            }
            // update main info
            tour.TourName = request.TourName;
            tour.Overview = request.Overview;
            tour.IsPrivate = request.IsPrivate;
            tour.Duration = request.Duration;
            tour.GroupSize = request.GroupSize;
            tour.MinAdults = request.MinAdults;
            tour.PricePerAdult = request.PricePerAdult;
            tour.PricePerChild = request.IncludeChildren ? request.PricePerChild : -1;
            tour.StartTime = request.StartTime;
            tour.StartPoint = request.StartPoint;
            tour.EndPoint = request.EndPoint;
            // update places
            tour.TourPlaces.Clear();
            //var tourPlaces = new List<TourPlace>();
            foreach (var placeId in request.PlaceIds)
            {
                tour.TourPlaces.Add(new TourPlace()
                {
                    PlaceId = placeId
                });
            }
            // update categories
            tour.TourCategories.Clear();
            //var tourCategories = new List<TourCategory>();
            foreach (var categoryId in request.CategoryIds)
            {
                tour.TourCategories.Add(new TourCategory()
                {
                    CategoryId = categoryId
                });
            }
            // update itineraries
            tour.Itineraries.Clear();
            //var itineraries = new List<Itinerary>();
            foreach (var itinerary in request.Itineraries)
            {
                tour.Itineraries.Add(new Itinerary()
                {
                    Title = itinerary.Title,
                    Content = itinerary.Content,
                });
            }
            // update expenses
            tour.Expenses.Clear();
            //var expenses = new List<Expense>();
            foreach (var expense in request.Expenses)
            {
                tour.Expenses.Add(new Expense()
                {
                    Content = expense.Content,
                    IsIncluded = expense.IsIncluded
                });
            }
            // update images
            foreach (var imageDto in request.Images)
            {
                if(imageDto.Id > 0)
                {
                    var image = await _context.TourImages.FirstOrDefaultAsync(x => x.Id == imageDto.Id);
                    if (imageDto.Deleted == true)
                    {
                        _context.TourImages.Remove(image);
                    }
                    else
                    {
                        if(imageDto.File != null)
                        {
                            //var image = await _context.TourImages.FirstOrDefaultAsync(x => x.Id == imageDto.Id);
                            image.Url = await _storageService.SaveImage(imageDto.File);
                        }
                    }
                }
                else
                {

                    tour.TourImages.Add(new TourImage()
                    {
                        Url = await _storageService.SaveImage(imageDto.File)
                    });
                }
            }

            await _context.SaveChangesAsync();


            return tour.Id;
        }

        // tour reviews
        public async Task<PagedResult<ReviewVm>> GetTourReviews(int tourId, int page, int perPage)
        {
            var query = _context.Reviews.Where(x => x.TourId == tourId).AsNoTracking()
                                        .OrderByDescending(x => x.DateModified)
                                        .Select(x => new ReviewVm()
                                        {
                                            Id = x.Id,
                                            Date = x.DateModified.ToString("dd/MM/yyyy"),
                                            Content = x.Content,
                                            Rating = x.Rating,
                                            Username = x.User.Username,
                                            UserAvatar = x.User.AvatarUrl ?? String.Empty
                                        });
            // paging
            // default values
            page = page == 0 ? 1 : page;
            perPage = perPage == 0 ? 4 : perPage;
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / perPage) + 1;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            return new PagedResult<ReviewVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = await query.ToListAsync()
            };
        }
        public async Task<int> CreateReview(int userId, int tourId, ReviewDTO request)
        {
            var review = _context.Reviews.Where(x => (x.UserId == userId) && (x.TourId == tourId)).FirstOrDefault();
            if (review == null)
            {
                // add new review
                review = new Review()
                {
                    Content = !String.IsNullOrEmpty(request.Content) ? request.Content : String.Empty,
                    Rating = request.Rating,
                    TourId = tourId,
                    UserId = userId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                };
            }
            else
            {
                review.Content = request.Content;
                review.Rating = request.Rating;
                review.DateModified = DateTime.Now;
            }

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            return review.Id;
        }



        public async Task<List<CategoryVm>> GetTopOrderedCategories(int tourId, int page, int perPage, DateTime requestDate)
        {
            var query = from category in _context.Categories
                        join tourCategory in _context.TourCategories on category.Id equals tourCategory.CategoryId
                        join tour in _context.Tours on tourCategory.TourId equals tour.Id
                        join order in _context.Orders on tour.Id equals order.TourId
                        where order.OrderDate >= requestDate && order.State.Equals("Confirmed")
                        group category by category.Id into categoryGroup
                        orderby categoryGroup.Count() descending
                        select new CategoryVm
                        {
                            Id = categoryGroup.Key,
                            CategoryName = categoryGroup.First().CategoryName,
                            OrderCount = categoryGroup.Count()
                        };

            //var resultCategories = new List<CategoryVm>();

            //foreach (var group in query)
            //{
            //    Console.WriteLine($"Id: {group.Key}, Count: {group.Count()}");
            //    foreach (var element in group)
            //    {
            //        if (!resultCategories.Any(x => x.Id == element.Id))
            //        {
            //            resultCategories.Add(new CategoryVm()
            //            {
            //                Id = element.Id,
            //                CategoryName = element.CategoryName
            //            });
            //        }
            //    }
            //}

            return await query.ToListAsync();
        }
    }
}
