using HappyVacation.Database;
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
                                    })
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
                                    Address = !String.IsNullOrEmpty(x.Address) ? $"{x.Address}, {x.Ward}, {x.District}, {x.Province}" 
                                                                              : $"{x.Ward}, {x.District}, {x.Province}",
                                    OpenCloseTime = x.OpenCloseTime,
                                    Latitude = x.Latitude,
                                    Longitude = x.Longitude,
                                    Images = x.SubTouristSiteImages.Select(img => new TouristSiteImageVm()
                                    {
                                        Id = img.Id,
                                        Url = img.Url
                                    })
                                }).FirstOrDefaultAsync();

            touristSite.Description = (await _context.SubTouristSites.Where(x => x.Id == touristSiteId).AsNoTracking()
                                .Select(x => x.Description).FirstOrDefaultAsync()).Split('&');

            touristSite.HighLights = (await _context.SubTouristSites.Where(x => x.Id == touristSiteId).AsNoTracking()
                                .Select(x => x.HighLights).FirstOrDefaultAsync()).Split('&');

            return touristSite;
        }

        public async Task<List<TouristSiteMainInfoVm>> GetTouristSitesInPlace(int placeId)
        {
            if (!_context.Places.Any(x => (x.Id == placeId)))
            {
                return null;
            }
            var touristSites = await _context.SubTouristSites.Where(x => x.PlaceId == placeId).AsNoTracking()
                               .Select(x => new TouristSiteMainInfoVm()
                               {
                                   Id = x.Id,
                                   SiteName = x.SiteName,
                                   ThumbnailUrl = (x.SubTouristSiteImages.Count() > 0) ? x.SubTouristSiteImages[0].Url : String.Empty
                               }).ToListAsync();

            return touristSites;
        }
    }
}
