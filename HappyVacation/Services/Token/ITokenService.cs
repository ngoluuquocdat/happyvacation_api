using HappyVacation.Database.Entities;

namespace HappyVacation.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(User user, List<string> roles);
    }
}
