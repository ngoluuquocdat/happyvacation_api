using HappyVacation.Database;
using HappyVacation.Database.Entities;
using HappyVacation.DTOs.Authen;
using HappyVacation.Services.Storage;
using HappyVacation.Services.Token;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HappyVacation.Repositories.Authen
{
    public class AuthenRepository : IAuthenRepository
    {
        private readonly MyDbContext _context ;
        private readonly ITokenService _tokenService;
        private readonly IStorageService _storageService;

        public AuthenRepository(MyDbContext context, ITokenService tokenService, IStorageService storageService)
        {
            _context = context;
            _tokenService = tokenService;
            _storageService = storageService;
        }

        public async Task<AuthenVm> Login(LoginRequest request)
        {
            var user = await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                                        .Where(u => u.Username.Equals(request.Username))
                                        .FirstOrDefaultAsync();

            if(user == null)
            {
                return null;
            }

            // check password
            // algorithm for password encoding, with key specified by user's key
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            // compare 2 arrays of byte: passwordHash from request vs PasswordHash from Db
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != user.PasswordHash[i])
                {
                    return null;
                }
            }

            var token = _tokenService.CreateToken(user, user.UserRoles.Select(x => x.Role.RoleName).ToList());

            return new AuthenVm()
            {
                Username = user.Username,
                FullName = $"{user.FirstName} {user.LastName}",
                Phone = user.Phone,
                Email = user.Email,
                AvatarUrl = !String.IsNullOrEmpty(user.AvatarUrl) ? user.AvatarUrl : String.Empty,
                Token = token
            };
        }

        public async Task<AuthenVm> Register(RegisterRequest request)
        {
            var existedUser = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if (existedUser != null)
            {
                return null;
            }

            // algorithm for password encoding
            using var hmac = new HMACSHA512();
            // new user info
            var newUser = new User()
            {
                Username = request.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PasswordSalt = hmac.Key,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                AvatarUrl = await _storageService.SaveImage(request.Avatar)
            };
            // assign 'Tourist' role to new user
            newUser.UserRoles.Add(
                new UserRole { RoleId = 3 }
            );

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var token = _tokenService.CreateToken(newUser, newUser.UserRoles.Select(x => x.Role.RoleName).ToList());

            return new AuthenVm()
            {
                Username = newUser.Username,
                FullName = $"{newUser.FirstName} {newUser.LastName}",
                Phone = newUser.Phone,
                Email = newUser.Email,
                Token = token
            };
        }
    }
}
