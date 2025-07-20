using BL.Models;
using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IBlManager _blManager;

        public JobController(IBlManager blManager)
        {
            _blManager = blManager;
        }

        [HttpGet("GetJobByCode/{code}")]
        public IActionResult GetJobByCode(int code)
        {
            return Ok(_blManager.JobBLManager.GetJobByCode(code));
        }

        [HttpPost("AddJob")]
        [Authorize(Roles = "Company")]
        public IActionResult AddJob([FromBody] JobBL job)
        {
            if (job == null)
            {
                return BadRequest("Invalid job data.");
            }

            _blManager.JobBLManager.AddJob(job);
            return Ok($"Job: {job.Code} was added successfully.");
        }

        [HttpGet("FindMatchingCandidates/{code}")]
        [Authorize(Roles = "Company")]
        public IActionResult FindMatchingCandidates(int code)
        {
            var matchingCandidates = _blManager.JobBLManager.GetJobOffersByJobCode(code);

            if (matchingCandidates == null || matchingCandidates.Count == 0)
            {
                return NotFound("No matching jobs found.");
            }

            return Ok(matchingCandidates);
        }

        [HttpGet("GetAppliedCandidates/{jobCode}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetAppliedCandidate(int jobCode)
        {
            return Ok(_blManager.JobBLManager.GetAppliedCandidatesByJobCode(jobCode));
        }

        [HttpGet("GetJobsForCompany/{companyCode}")]
        public IActionResult GetJobsForCompany(int companyCode)
        {
            return Ok(_blManager.JobBLManager.GetCompanyJobs(companyCode));
        }

        [HttpDelete("NotSeekingWorkers/{code}")]
        [Authorize(Roles = "Company")]
        public IActionResult NotSeekingWorkers(int code)
        {
            _blManager.JobBLManager.NotSeekingWorkers(code);
            return Ok($"Job : {code} is no longer seeking workers.");
        }
    }
}