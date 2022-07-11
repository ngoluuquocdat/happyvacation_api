using HappyVacation.DTOs.Authen;

namespace HappyVacation.Repositories.Authen
{
    public interface IAuthenRepository
    {
        Task<AuthenVm> Register(RegisterRequest request);
        Task<AuthenVm> Login(LoginRequest request);
        Task<AuthenVm> AdminLogin(LoginRequest request);
        Task<int?> ChangePassword(int userId, ChangePasswordRequest request);
    }
}
