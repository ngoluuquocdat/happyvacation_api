using HappyVacation.DTOs.Providers;
using HappyVacation.DTOs.Providers.ProviderManage;
using HappyVacation.DTOs.Tours;
using HappyVacation.Repositories.Orders;
using HappyVacation.Repositories.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IOrderRepository _orderRepository;

        public ProvidersController(IProviderRepository providerRepository, IOrderRepository orderRepository)
        {
            _providerRepository = providerRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet("{providerId:int}")]
        public async Task<ActionResult> GetProviderById(int providerId)
        {

            var result = await _providerRepository.GetProviderById(providerId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("me")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> GetProviderMe()
        {
            var claimsPrincipal = this.User;
            var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value); 

            var result = await _providerRepository.GetProviderProfile(userId);
            if (result == null)
            {
                return Forbid();
            }

            return Ok(result);
        }

        [HttpPost("registration")]
        [Authorize(Roles = "Tourist")]
        public async Task<ActionResult> ProviderRegistration(ProviderRegistrationRequest request)
        {
            var claimsPrincipal = this.User;
            var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

            var newRegistrationId = await _providerRepository.CreateProviderRegistration(userId, request);

            if (newRegistrationId == 0)
            {
                return Forbid();
            }

            var newRegistration = await _providerRepository.GetProviderRegistrationById(newRegistrationId);

            return Ok(newRegistration);
        }

        [HttpGet("me/registration")]
        [Authorize(Roles = "Tourist")]
        public async Task<ActionResult> GetProviderRegistration()
        {
            var claimsPrincipal = this.User;
            var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

            var result = await _providerRepository.GetProviderRegistration(userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("me")]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> UpdateProviderMe([FromForm] UpdateProviderRequest request)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _providerRepository.UpdateProvider(userId, request);
                if (result == null)
                {
                    return Forbid();
                }

                var updatedProvider = await _providerRepository.GetProviderProfile(userId);
                return Ok(updatedProvider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpGet("{providerId:int}/tours")]
        public async Task<ActionResult> GetTours(int providerId, [FromQuery] string? sort, int page, int perPage)
        {
            var result = await _providerRepository.GetTours(providerId, sort, page, perPage);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
       
        [HttpGet("me/tours")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> GetToursManage([FromQuery] GetTourManageRequest request)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _providerRepository.GetToursManage(userId, request);
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

        [HttpGet("me/tours/simple")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> GetSimplifiedTours()
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _providerRepository.GetSimplifiedTours(userId);
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

        [HttpGet("me/orders")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> GetTourProviderOrders([FromQuery] string? state, int page, int perPage, string? keyword)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _orderRepository.GetTourProviderOrders(userId, state, page, perPage, keyword);
                if(result == null)
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

        [HttpGet("me/orders/report")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> GetOrderExport([FromQuery] string startDate, string endDate)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _providerRepository.GetOrderExport(userId, startDate, endDate);
                if (result == "Forbid")
                {
                    return Forbid();
                }
                return Ok( new
                {
                    filePath = result
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpGet("registrations")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetRegistrations([FromQuery] GetProviderRegistrationRequest request)
        {
            var result = await _providerRepository.GetRegistrations(request);

            return Ok(result);
        }

        [HttpPut("registrations/{registrationId}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ApproveProviderRegistration(int registrationId)
        {
            var NOT_FOUND_ERROR = -1;

            try
            {
                var result = await _providerRepository.ApproveProviderRegistration(registrationId);
                if (result == NOT_FOUND_ERROR)
                {
                    return NotFound();
                }
                if (result == 0)
                {
                    return BadRequest("Something wrong");
                }

                var updatedRegistration = await _providerRepository.GetProviderRegistrationById(result);

                return Ok(updatedRegistration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpPut("{providerId}/disable")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DisableProvider(int providerId)
        {
            try
            {
                var result = await _providerRepository.DisableProvider(providerId);
                if (result == 0)
                {
                    return NotFound();
                }

                var updatedProvider = await _providerRepository.GetProviderById(result);

                return Ok(updatedProvider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpPut("{providerId}/enable")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EnableProvider(int providerId)
        {
            try
            {
                var result = await _providerRepository.EnableProvider(providerId);
                if (result == 0)
                {
                    return NotFound();
                }

                var updatedProvider = await _providerRepository.GetProviderById(result);

                return Ok(updatedProvider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpGet("manage")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetProvidersManage([FromQuery] GetProvidersManageRequest request)
        {
            var result = await _providerRepository.GetProvidersManage(request);

            return Ok(result);
        }

        [HttpGet("{providerId}/manage")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetProviderDetailManage(int providerId)
        {
            var result = await _providerRepository.GetProviderDetailManage(providerId);

            return Ok(result);
        }

        [HttpGet("{providerId}/manage/tours")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetToursAdmin(int providerId, [FromQuery] int page, int perPage)
        {
            var result = await _providerRepository.GetToursAdmin(providerId, page, perPage);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{providerId}/manage/revenue")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetRevenueAdmin(int providerId, [FromQuery] int quarterIndex, int year)
        {
            var result = await _providerRepository.GetRevenueByQuarter(quarterIndex, year, userId: 0, providerId: providerId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
