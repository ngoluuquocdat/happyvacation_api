using HappyVacation.DTOs.Providers;
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
            var claimsPrincipal = this.User;
            var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

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
    }
}
