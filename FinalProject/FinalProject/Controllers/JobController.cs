using BL.Models;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IBlManager _blManager;
        public JobController(IBlManager blManager)
        {
            _blManager = blManager;
        }

        [HttpGet("GetJobByCode/{code}")]
        public IActionResult GetJobByCode(int code)
        {
            return Ok(_blManager.JobBLManager.GetJobByCode(code));
        }

        [HttpPost]
        [Route("AddJob")]
        public IActionResult AddJobSeeker([FromBody] JobBL job)
        {
            if (job == null)
            {
                return BadRequest("Invalid job seeker data.");
            }

            _blManager.JobBLManager.AddJob(job);
            return Ok($"Job: {job.Code} was added successfully.");
        }

        [HttpGet("FindMatchingCandidates/{code}")]
        public IActionResult FindMatchingCandidates(int code)
        {
            var matchingCandidates = _blManager.JobBLManager.GetJobOffersByJobCode(code);

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

        [HttpGet("GetAppliedCandidates/{int jobCode}")]
        public IActionResult GetAppliedCandidate(int code)
        {
            return Ok(_blManager.JobBLManager.GetAppliedCandidatesByJobCode(code));
        }


    }
}
