using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Users;

namespace HappyVacation.Repositories.Users
{
    public interface IUserRepository
    {
        Task<UserVm> GetUserById(int userId);
        Task<bool?> UpdateUser(int userId, UpdateUserRequest request);
        Task<bool?> CheckEmail(string email, string password);
        Task<bool?> CheckUserEnabled(int userId);

        // wish list functions
        Task<int> AddToWishList(int userId, int tourId);
        Task<int> RemoveFromWishList(int userId, int tourId);
        Task<List<WishItemVm>> GetWishList(int userId);

        // for admin
        Task<PagedResult<UserVm>> GetUsers(GetUsersManageRequest request);
        Task<int> DisableUser(int userId);
        Task<int> EnableUser(int userId);
    }
}
