using HappyVacation.Repositories.Providers;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderRepository _providerRepository;

        public ProvidersController(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
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

        [HttpGet("{providerId:int}/tours")]
        public async Task<ActionResult> GetTours(int providerId, [FromQuery] string sort, int page, int perPage)
        {
            var result = await _providerRepository.GetTours(providerId, sort, page, perPage);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
