using HappyVacation.Database;
using HappyVacation.Database.Entities;
using HappyVacation.DTOs.Common;
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

        public async Task<TourVm> GetTourById(int tourId)
        {
            if (!_context.Tours.Any(x => (x.Id == tourId)))
            {
                return null;
            }
            //var tour1 = _context.Tours.Include(x => x.TourCategories).ThenInclude(x => x.Category);
            //var result = tour1.Where(x => x.TourCategories.All(tc => tc.CategoryId == cateId));
            //result = result.Concat(tour1.Where(x => x.TourCategories.Any(tc => tc.CategoryId == cateId)));

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
                                       PlaceId = x.PlaceId,
                                       Location = x.Location,
                                       Destination = x.Destination,
                                       Reviews = x.Reviews.Count(),
                                       Rating = (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Average(r => r.Rating), 2) : 0,                                      
                                       ProviderId = x.ProviderId,
                                       ProviderName = x.Provider.ProviderName,
                                       ProviderAvatar = x.Provider.ThumbnailUrl,
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
                                       Categories = x.TourCategories.Select(tc => new CategoryVm()
                                       {
                                           Id = tc.CategoryId,
                                           CategoryName = tc.Category.CategoryName
                                       })
                                   }).FirstOrDefaultAsync();

            return tour;
        }
        public async Task<int> Create(CreateTourRequest request)
        {
            // tour's main info
            Tour tour = new Tour()
            {
                TourName = request.TourName,
                Overview = request.Overview,
                Duration = request.Duration,
                GroupSize = request.GroupSize,
                MinAdults = request.MinAdults,
                Location = request.Location,    
                Destination = request.Destination,
                PlaceId = request.PlaceId,
                PricePerAdult = request.PricePerAdult,
                PricePerChild = request.PricePerChild,
                ProviderId = 1
            };
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

            tour.TourCategories = tourCategories;
            tour.Itineraries = itineraries;
            tour.Expenses = expenses;
            tour.TourImages = images;

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            return tour.Id;
        }

        public async Task<PagedResult<ReviewVm>> GetTourReviews(int tourId, int page, int perPage)
        {
            var query = _context.Reviews.Where(x => x.TourId == tourId).AsNoTracking()
                                        .Select(x => new ReviewVm()
                                        {
                                            Id = x.Id,
                                            Date = x.DateCreated.ToShortDateString(),
                                            Content = x.Content,
                                            Rating = x.Rating,
                                            Username = x.User.Username,
                                            UserAvatar = x.User.AvatarUrl ?? String.Empty
                                        });
            // paging
            int totalCount = query.Count();
            int totalPages = totalCount / perPage;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            return new PagedResult<ReviewVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = await query.ToListAsync()
            };
        }
    }
}
