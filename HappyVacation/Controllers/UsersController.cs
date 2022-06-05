using HappyVacation.DTOs.Users;
using HappyVacation.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Get()                
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _userRepository.GetUserById(userId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpPut("me")]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] UpdateUserRequest request)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _userRepository.UpdateUser(userId, request);
                if (result == null)
                {
                    return NotFound();
                }

                var updatedUser = await _userRepository.GetUserById(userId);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpGet("me/wish-list")]
        [Authorize]
        public async Task<IActionResult> GetWishList()
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _userRepository.GetWishList(userId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpPost("me/wish-list")]
        [Authorize]
        public async Task<IActionResult> AddToWishList([FromQuery] int tourId)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _userRepository.AddToWishList(userId, tourId);
                if(result == 0)
                {
                    return Ok("Already in wish list");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpDelete("me/wish-list")]
        [Authorize]
        public async Task<IActionResult> RemoveFromWishList([FromQuery] int tourId)
        {
            var NOT_FOUND_ERROR = -1;
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _userRepository.RemoveFromWishList(userId, tourId);
                if(result == NOT_FOUND_ERROR)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }
    }
}
