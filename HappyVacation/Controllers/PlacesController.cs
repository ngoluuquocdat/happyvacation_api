using HappyVacation.Repositories.Places;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceRepository _placeRepository;

        public PlacesController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<ActionResult> GetPlaces([FromQuery] int count, string? sort)
        {
            var result = await _placeRepository.GetPlaces(count, sort);
            return Ok(result);
        }

        [HttpGet("{placeId}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetPlaceById(int placeId)
        {
            var result = await _placeRepository.GetPlaceById(placeId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{placeId}/touristSites")]
        [AllowAnonymous]
        public async Task<ActionResult> GetTouristSitesInPlace(int placeId, [FromQuery] int page, int perPage)
        {
            var result = await _placeRepository.GetTouristSitesInPlace(placeId, page, perPage);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("touristSites/{touristSiteId}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetTouristSiteById(int touristSiteId)
        {
            var result = await _placeRepository.GetTouristSiteById(touristSiteId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
