using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Providers;
using HappyVacation.DTOs.Tours;

namespace HappyVacation.Repositories.Providers
{
    public interface IProviderRepository
    {
        Task<ProviderVm> GetProviderById(int providerId);
        Task<PagedResult<TourMainInfoVm>> GetTours(int providerId, string sort, int page, int perPage);
    }
}
