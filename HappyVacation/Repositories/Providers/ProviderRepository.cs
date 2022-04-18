using HappyVacation.Database;
using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Providers;
using HappyVacation.DTOs.Tours;
using HappyVacation.Services.Storage;
using Microsoft.EntityFrameworkCore;

namespace HappyVacation.Repositories.Providers
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly MyDbContext _context;
        private readonly IStorageService _storageService;

        public ProviderRepository(MyDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
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
                                                DateCreated = x.DateCreated,
                                                Description = x.Description,
                                                TourAvailable = x.Tours.Count(),
                                            }).FirstOrDefaultAsync();
            provider.AverageRating = (float)Math.Round(
                                        (_context.Tours.Where(x => x.ProviderId == providerId)
                                        .Select(x => (x.Reviews.Count() != 0) ? x.Reviews.Average(r => r.Rating) : -1)
                                        .ToList())
                                        .Where(x => x != -1)                                
                                        .Average(), 2);
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
                                                Description = x.Description
                                            }).FirstOrDefaultAsync();
            return provider;
        }

        public async Task<PagedResult<TourMainInfoVm>> GetTours(int providerId, string sort, int page, int perPage)
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
                        query = query.OrderBy(x => x.PricePerAdult * x.MinAdults);
                        break;
                    case "price-down":
                        query = query.OrderByDescending(x => x.PricePerAdult * x.MinAdults);
                        break;
                    case "rating":
                        query = query.OrderByDescending(x => (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Average(r => r.Rating), 2) : 0);
                        break;
                }
            }

            // 2. paging
            int totalCount = query.Count();
            int totalPages = totalCount / perPage;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            var tours = await query.Select(x => new TourMainInfoVm()
            {
                Id = x.Id,
                TourName = x.TourName,
                Reviews = x.Reviews.Count(),
                Rating = (x.Reviews.Count() != 0) ? (float)Math.Round(x.Reviews.Average(r => r.Rating), 2) : 0,
                IsPrivate = x.IsPrivate,
                Duration = x.Duration,
                MinPrice = x.PricePerAdult * x.MinAdults,
                ThumbnailPath = (x.TourImages.Count() > 0) ? x.TourImages[0].Url : String.Empty
            }).ToListAsync();

            return new PagedResult<TourMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = tours
            };

            return null;
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
    }
}
