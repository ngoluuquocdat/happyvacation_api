using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Places;

namespace HappyVacation.Repositories.Places
{
    public interface IPlaceRepository
    {
        // place
        Task<List<PlaceVm>> GetPlaces(int count, string? sort);
        Task<PlaceDetailVm> GetPlaceById(int placeId);

        // tourist site
        Task<PagedResult<TouristSiteMainInfoVm>> GetTouristSitesInPlace(int placeId, int page, int perPage);
        Task<TouristSiteVm> GetTouristSiteById(int touristSiteId);
    }
}
