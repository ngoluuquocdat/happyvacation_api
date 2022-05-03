using HappyVacation.DTOs.Hotels;
using HappyVacation.Repositories.Hotels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetHotels([FromQuery] GetHotelRequest request)
        {
            try
            {
                var result = await _hotelRepository.GetHotels(request);
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
