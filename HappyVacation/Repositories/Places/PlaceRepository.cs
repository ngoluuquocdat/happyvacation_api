using HappyVacation.Database;
using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Places;
using HappyVacation.Services.Storage;
using Microsoft.EntityFrameworkCore;

namespace HappyVacation.Repositories.Places
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly MyDbContext _context;
        private readonly IStorageService _storageService;

        public PlaceRepository(MyDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<PlaceVm>> GetPlaces(int count, string? sort)
        {
            var requestDate = DateTime.Now.AddMonths(-3);       // 3 months ago from current date

            var places = await _context.Places.AsNoTracking()
                             .Select(place => new PlaceVm()
                             {
                                 Id = place.Id,
                                 PlaceName = place.PlaceName,
                                 ThumbnailUrl = (place.PlaceImages.Count() > 0) ? place.PlaceImages[0].Url : place.ThumbnailUrl
                             }).AsSplitQuery().ToListAsync();

            if (!String.IsNullOrEmpty(sort))
            {
                for(int i = 0; i < places.Count; i++)
                {
                    places[i].OrderCount = await GetOrderCount(places[i].Id, requestDate);
                }
                // order places by orders count
                places = places.OrderByDescending(p => p.OrderCount).ThenBy(x => x.Id).ToList();
            }                              

            if(count != 0)
            {
                places = places.Take(count).ToList();
            }

            return places;
        }

        public async Task<int> GetOrderCount(int placeId, DateTime requestDate)
        {
            var tours = await _context.Tours.Where(x => x.TourPlaces.Any(tp => tp.PlaceId == placeId)).AsNoTracking()
                                    .Select(x => new
                                    {
                                        TourId = x.Id,
                                        OrderCount = x.Orders.Where(o => o.OrderDate.Date >= requestDate && o.State.Equals("confirmed")).Count()
                                    }).ToListAsync();
            return tours.Sum(x => x.OrderCount);
        }

        public async Task<PlaceDetailVm> GetPlaceById(int placeId)
        {
            if (!_context.Places.Any(x => (x.Id == placeId)))
            {
                return null;
            }

            var place = await _context.Places.Where(x => x.Id == placeId).AsNoTracking()
                                .Select(x => new PlaceDetailVm()
                                {
                                    Id = x.Id,
                                    PlaceName = x.PlaceName,
                                    ThumbnailUrl = x.ThumbnailUrl,
                                    Latitude = x.Latitude,
                                    Longitude = x.Longitude,
                                    Images = x.PlaceImages.Select(img => new PlaceImageVm()
                                    {
                                        Id = img.Id,
                                        Url = img.Url
                                    }),
                                    TravelTips = x.TravelTips.Select(tip => new TravelTipVm()
                                    {
                                        Id = tip.Id,
                                        Title = tip.Title,
                                        Content = tip.Content
                                    }),
                                    OverviewVideoUrl = x.OverviewVideoUrl,
                                    TourCount = x.TourPlaces.Count(),
                                    SubTouristSiteCount = x.SubTouristSites.Count()
                                }).FirstOrDefaultAsync();

            place.Description = (await _context.Places.Where(x => x.Id == placeId).AsNoTracking()
                                .Select(x => x.Description).FirstOrDefaultAsync()).Split('&');

            return place;
        }

        public async Task<TouristSiteVm> GetTouristSiteById(int touristSiteId)
        {
            if (!_context.SubTouristSites.Any(x => (x.Id == touristSiteId)))
            {
                return null;
            }

            var touristSite = await _context.SubTouristSites.Where(x => x.Id == touristSiteId).AsNoTracking()
                                .Select(x => new TouristSiteVm()
                                {   
                                    Id = x.Id,
                                    SiteName = x.SiteName,
                                    PlaceId = x.PlaceId,
                                    PlaceName = x.Place.PlaceName,
                                    Address = !String.IsNullOrEmpty(x.Address) ? $"{x.Address}, {x.Ward}, {x.District}, {x.Province}" 
                                                                              : $"{x.Ward}, {x.District}, {x.Province}",
                                    OpenCloseTime = x.OpenCloseTime,
                                    Latitude = x.Latitude,
                                    Longitude = x.Longitude,
                                    Images = x.SubTouristSiteImages.Select(img => new TouristSiteImageVm()
                                    {
                                        Id = img.Id,
                                        Url = img.Url
                                    }),
                                    OverviewVideoUrl = x.OverviewVideoUrl
                                }).FirstOrDefaultAsync();

            touristSite.Description = (await _context.SubTouristSites.Where(x => x.Id == touristSiteId).AsNoTracking()
                                .Select(x => x.Description).FirstOrDefaultAsync()).Split('&');

            touristSite.HighLights = (await _context.SubTouristSites.Where(x => x.Id == touristSiteId).AsNoTracking()
                                .Select(x => x.HighLights).FirstOrDefaultAsync()).Split('&');

            return touristSite;
        }

        public async Task<PagedResult<TouristSiteMainInfoVm>> GetTouristSitesInPlace(int placeId, int page, int perPage)
        {
            if (!_context.Places.Any(x => (x.Id == placeId)))
            {
                return null;
            }
            var query = _context.SubTouristSites.Where(x => x.PlaceId == placeId).AsNoTracking();

            // paging
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / perPage) + 1;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            var touristSites = await query.Select(x => new TouristSiteMainInfoVm()
                                           {
                                               Id = x.Id,
                                               SiteName = x.SiteName,
                                               ThumbnailUrl = (x.SubTouristSiteImages.Count() > 0) ? x.SubTouristSiteImages[0].Url : String.Empty
                                           }).ToListAsync();

            return new PagedResult<TouristSiteMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = touristSites
            };
        }
    }
}
