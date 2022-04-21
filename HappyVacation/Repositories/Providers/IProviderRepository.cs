using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Providers;
using HappyVacation.DTOs.Tours;

namespace HappyVacation.Repositories.Providers
{
    public interface IProviderRepository
    {
        Task<ProviderVm> GetProviderById(int providerId);
        Task<ProviderProfileVm> GetProviderProfile(int userId);
        Task<bool?> UpdateProvider(int userId, UpdateProviderRequest request);

        // get tours functions for user 
        Task<PagedResult<TourMainInfoVm>> GetTours(int providerId, string? sort, int page, int perPage);     

        // get tours functions for provider
        Task<PagedResult<TourMainInfoManageVm>> GetToursManage(int userId, GetTourManageRequest request);   
        
    }
}
