using HappyVacation.Database;
using HappyVacation.DTOs.Users;
using HappyVacation.Services.Storage;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HappyVacation.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        private readonly IStorageService _storageService;

        public UserRepository(MyDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<UserVm> GetUserById(int userId)
        {
            if (!_context.Users.Any(x => (x.Id == userId)))
            {
                return null;
            }
            var user = await _context.Users.Where(x => x.Id == userId).AsNoTracking()
                                        .Select(x => new UserVm()
                                        {
                                            Username = x.Username,
                                            FirstName = x.FirstName,
                                            LastName = x.LastName,
                                            Phone = x.Phone,
                                            Email = x.Email,
                                            AvatarUrl = !String.IsNullOrEmpty(x.AvatarUrl) ? x.AvatarUrl : String.Empty,
                                        }).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool?> UpdateUser(int userId, UpdateUserRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if(user == null)
            {
                return null;
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Phone = request.Phone;
            
            // save new avatar 
            if(request.Avatar != null)
            {
                user.AvatarUrl = await _storageService.SaveImage(request.Avatar);
            }

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        // change email 
        public async Task<bool?> CheckEmail(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email.ToLower()));
            if(user == null)
            {
                return null;
            }
            // check password
            // algorithm for password encoding, with key specified by user's key
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            // compare 2 arrays of byte: passwordHash from request vs PasswordHash from Db
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != user.PasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
