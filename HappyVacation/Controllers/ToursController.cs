using HappyVacation.DTOs.Reviews;
using HappyVacation.DTOs.Tours;
using HappyVacation.Repositories.Tours;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetTours([FromQuery] GetTourRequest request)
        {
            try
            {
                var result = await _tourRepository.GetTours(request);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }

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


        // tour manage for provider
        [HttpPut("{tourId:int}/providingState")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> ChangeTourProvidingState(int tourId)
        {
            try
            {
                var currentUser = HttpContext.User;
                var userId = Int32.Parse(currentUser.FindFirst("id").Value);

                var result = await _tourRepository.ChangeTourProvidingState(userId, tourId);

                if (result == -1)
                {
                    return Forbid();
                }
                var updatedTour = await _tourRepository.GetTourByIdManage(result);
                return Ok(updatedTour);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }       
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

            // get new tour created
            var newTour = await _tourRepository.GetTourById(newTourId);

            return CreatedAtAction(nameof(GetTourById), new { tourId = newTourId }, newTour);
        }
        [HttpPut("{tourId}")]
        public async Task<ActionResult> UpdateTour(int tourId, [FromForm] UpdateTourRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid data.");
                }

                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _tourRepository.UpdateTour(userId, tourId, request);
                if(result == -1)
                {
                    return Forbid();
                }

                // get updated tour
                var updatedTour = await _tourRepository.GetTourById(result);

                return Ok(updatedTour);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }          
        }


        // tour reviews

        [HttpGet("{tourId:int}/reviews")]
        public async Task<ActionResult> GetTourReviews(int tourId, [FromQuery] int page, int perPage)
        {
            var result = await _tourRepository.GetTourReviews(tourId, page, perPage);

            return Ok(result);
        }

        [HttpPost("{tourId:int}/reviews")]
        [Authorize]
        public async Task<ActionResult> CreateReview(int tourId, ReviewDTO request)
        {
            var currentUser = HttpContext.User;
            var userId = Int32.Parse(currentUser.FindFirst("id").Value);

            var result = await _tourRepository.CreateReview(userId, tourId, request);

            return Ok(result);
        }


        [HttpGet("topOrderedCategories")]
        public async Task<ActionResult> GetTopOrderedCategory()
        {
            try
            {
                var result = await _tourRepository.GetTopOrderedCategories(0, 0, 0, DateTime.MinValue);
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