using BL;
using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        private IBlManager _blManager;
        public JobSeekerController(IBlManager blManager)
        {
            _blManager = blManager;
        }

        [HttpGet("GetJobSeekerById/{id}")]
        public IActionResult GetJobSeekerById(int id)
        {
            return Ok(_blManager.JobSeekerBLManager.GetJobSeekerById(id));
        }

        [HttpPost]
        [Route("AddJobSeeker")]
        public IActionResult AddJobSeeker([FromBody] JobSeekerBL jobSeeker)
        {
            if (jobSeeker == null)
            {
                return BadRequest("Invalid job seeker data.");
            }

            _blManager.JobSeekerBLManager.AddJobSeeker(jobSeeker);
            return Ok($"Job seeker:{jobSeeker.Id} added successfully.");
        }

        [HttpGet("FindMatchingCandidates/{code}")]
        public IActionResult FindMatchingCandidates(int code) {
            var matchingCandidates = _blManager.JobBLManager.FindMatchingCandidates(code);

            //maybe only check in react program:
            if (matchingCandidates == null || matchingCandidates.Count == 0)
            {
                return NotFound("No matching jobs found.");
            }
            return Ok(matchingCandidates);
        }

        [HttpDelete("NotSeekingWorkers/{code}")]
        public IActionResult NotSeekingWorkers(int code)
        {
            _blManager.JobBLManager.NotSeekingWorkers(code);
            return Ok($"Job : {code} is no longer seeking workers.");
        }
    }
}
