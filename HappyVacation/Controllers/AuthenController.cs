using HappyVacation.DTOs.Authen;
using HappyVacation.Repositories.Authen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenRepository _authenRepository;

        public AuthenController(IAuthenRepository authenRepository)
        {
            _authenRepository = authenRepository;
        }

        [HttpPost("login/admin")]
        [AllowAnonymous]
        public async Task<ActionResult> AdminLogin(LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _authenRepository.AdminLogin(request);
            if (result == null)
            {
                return Forbid();
            }

            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _authenRepository.Login(request);
            if (result == null)
            {
                return Unauthorized(value: "Invalid username or password.");
            }

            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _authenRepository.Register(request);
            if (result == null)
            {
                return BadRequest(error: "Username already exists.");
            }

            return Ok(result);
        }
    }
}
