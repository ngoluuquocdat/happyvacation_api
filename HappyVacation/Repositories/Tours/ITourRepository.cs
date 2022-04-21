using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Reviews;
using HappyVacation.DTOs.Tours;

namespace HappyVacation.Repositories.Tours
{
    public interface ITourRepository
    {
        Task<PagedResult<TourMainInfoVm>> GetTours(GetTourRequest request);
        Task<TourVm> GetTourById(int tourId);
        Task<TourMainInfoManageVm> GetTourByIdManage(int tourId);
        Task<int> Create(CreateTourRequest request);
        Task<int> ChangeTourProvidingState(int userId, int tourId);
        Task<int> UpdateTour(int userId, int tourId, UpdateTourRequest request);

        // tour reviews
        Task<PagedResult<ReviewVm>> GetTourReviews(int tourId, int page, int perPage);
        Task<int> CreateReview(int userId, int tourId, ReviewDTO request);



        Task<List<CategoryVm>> GetTopOrderedCategories(int tourId, int page, int perPage, DateTime requestDate);
    }
}
