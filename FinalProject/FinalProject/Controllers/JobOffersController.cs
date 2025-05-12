using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOffersController : ControllerBase
    {
        private IBlManager _blManager;
        public JobOffersController(IBlManager blManager)
        {
            _blManager = blManager;
        }

        [HttpGet("FindMatchingCandidates/{jobCode}")]
        public IActionResult FindCandidatesByJobCode(int jobCode)
        {
            var candidates = _blManager.JobOffersBLManager.FindCandidatesByJobCode(jobCode);
            if (candidates == null || candidates.Count == 0)
            {
                return NotFound("No candidates found for the given job code.");
            }
            return Ok(candidates);
        }

        [HttpGet("GetAllJobOffers/{id}")]
        public IActionResult GetAllJobOffers(int id)
        {
            var jobOffers = _blManager.JobOffersBLManager.FindMatchesById(id);
            if (jobOffers == null || jobOffers.Count == 0)
            {
                return NotFound("No suitable jobs found for the given seeker.");
            }
            return Ok(jobOffers);
        }
    }
}
