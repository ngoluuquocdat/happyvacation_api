using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Reviews;
using HappyVacation.DTOs.Tours;

namespace HappyVacation.Repositories.Tours
{
    public interface ITourRepository
    {
        Task<PagedResult<TourMainInfoVm>> GetTours(GetTourRequest request);
        Task<int> Create(CreateTourRequest request);
        Task<TourVm> GetTourById(int tourId);
        Task<PagedResult<ReviewVm>> GetTourReviews(int tourId, int page, int perPage);
        Task<int> CreateReview(int userId, int tourId, ReviewDTO request);



        Task<List<CategoryVm>> GetTopOrderedCategories(int tourId, int page, int perPage, DateTime requestDate);
    }
}
