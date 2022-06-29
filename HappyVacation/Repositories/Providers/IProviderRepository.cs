using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Providers;
using HappyVacation.DTOs.Providers.ProviderManage;
using HappyVacation.DTOs.Tours;

namespace HappyVacation.Repositories.Providers
{
    public interface IProviderRepository
    {
        Task<bool?> CheckProviderEnabled(int userId);
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

        // get revenue by quater (for admin and provider)
        Task<RevenueVm> GetRevenueByQuarter(int quarterIndex, int year, int userId = 0, int providerId = 0);

        // get revenue by month (for provider)
        Task<RevenueVm> GetRevenueByMonth(int month, int year, int userId = 0);

        // get overall statistic (for provider)
        Task<OverallStatisticVm> GetOverallStatistic(int userId);

        // get statistic for provider
        //Task<StatisticVm> GetStatisticByQuarter(int userId, int quarterIndex, string endDate);

        // tour provider registration
        Task<int> CreateProviderRegistration(int userId, ProviderRegistrationRequest request);
        Task<int> DeleteProviderRegistration(int userId, int registrationId);
        Task<ProviderRegistrationVm> GetProviderRegistration(int userId);   // get registration of a user
        Task<ProviderRegistrationVm> GetProviderRegistrationById(int registrationId);
        Task<PagedResult<ProviderRegistrationVm>> GetRegistrations(GetProviderRegistrationRequest request);

        // admin's features
        Task<int> ApproveProviderRegistration(int registrationId);
        Task<int> RejectProviderRegistration(int registrationId);
        Task<int> DisableProvider(int providerId);
        Task<int> EnableProvider(int providerId);
        Task<PagedResult<ProviderManageMainInfoVm>> GetProvidersManage(GetProvidersManageRequest request);
        Task<ProviderManageDetailVm> GetProviderDetailManage(int providerId);
        Task<PagedResult<TourMainInfoManageVm>> GetToursAdmin(int providerId, int page = 1, int perPage = 4);
    }
}
