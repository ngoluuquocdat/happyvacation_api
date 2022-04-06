using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Reviews;
using HappyVacation.DTOs.Tours;

namespace HappyVacation.Repositories.Tours
{
    public interface ITourRepository
    {
        //Task<List<TourMainInfoVm>> GetProducts();
        Task<int> Create(CreateTourRequest request);
        Task<TourVm> GetTourById(int tourId);
        Task<PagedResult<ReviewVm>> GetTourReviews(int tourId, int page, int perPage);
    }
}
