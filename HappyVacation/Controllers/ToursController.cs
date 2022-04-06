using HappyVacation.DTOs.Tours;
using HappyVacation.Repositories.Tours;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly ITourRepository _tourRepository;

        public ToursController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }


        [HttpGet("{tourId:int}")]
        public async Task<ActionResult> GetTourById(int tourId)
        {

            var result = await _tourRepository.GetTourById(tourId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{tourId:int}/reviews")]
        public async Task<ActionResult> GetTourReviews(int tourId, [FromQuery] int page, int perPage)
        {
            var result = await _tourRepository.GetTourReviews(tourId, page, perPage);

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateTour([FromForm] CreateTourRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            int newTourId = await _tourRepository.Create(request);
            if (newTourId == 0)
            {
                return StatusCode(500);
            }

            // get new product created
            var newTour = await _tourRepository.GetTourById(newTourId);

            return CreatedAtAction(nameof(GetTourById), new { tourId = newTourId }, newTour);
        }

    }
}