using HappyVacation.DTOs.Users;

namespace HappyVacation.Repositories.Users
{
    public interface IUserRepository
    {
        Task<UserVm> GetUserById(int userId);
        Task<bool?> UpdateUser(int userId, UpdateUserRequest request);
        Task<bool?> CheckEmail(string email, string password);  
    }
}
