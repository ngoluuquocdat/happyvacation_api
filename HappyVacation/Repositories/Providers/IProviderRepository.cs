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
        // get tour simple view model (id and name)
        Task<List<TourSimpleVm>> GetSimplifiedTours(int userId);

        // get order report
        Task<string> GetOrderExport(int userId, string startDate, string endDate);

        // tour provider registration
        Task<int> CreateProviderRegistration(int userId, ProviderRegistrationRequest request);
        Task<ProviderRegistrationVm> GetProviderRegistration(int userId);   // get registration of a user
        Task<ProviderRegistrationVm> GetProviderRegistrationById(int registrationId);
        Task<PagedResult<ProviderRegistrationVm>> GetRegistrations(GetProviderRegistrationRequest request);

        // admin's features
        Task<int> ApproveProviderRegistration(int registrationId);
    }
}
