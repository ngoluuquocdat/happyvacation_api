using HappyVacation.DTOs.Places;

namespace HappyVacation.Repositories.Places
{
    public interface IPlaceRepository
    {
        // place
        Task<PlaceDetailVm> GetPlaceById(int placeId);

        // tourist site
        Task<List<TouristSiteMainInfoVm>> GetTouristSitesInPlace(int placeId);
        Task<TouristSiteVm> GetTouristSiteById(int touristSiteId);
    }
}
