using BL.Models;
using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        private int GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
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
            // Optionally, set job.CompanyId = GetUserIdFromToken();
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
                return NotFound("No matching candidates found.");
            }

            return Ok(matchingCandidates);
        }
        [HttpGet("GetJobOffersWithCandidates/{jobCode}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetJobOffersWithCandidates(int jobCode)
        {
            var offers = _blManager.JobBLManager.GetJobOffersWithCandidatesByJobCode(jobCode);           
            if (offers == null || offers.Count == 0)
            {
                return NotFound("No matching candidates found.");
            }
            return Ok(offers);
        }

        [HttpGet("GetAppliedCandidates/{jobCode}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetAppliedCandidate(int jobCode)
        {
            var appliedCandidates = _blManager.JobBLManager.GetAppliedCandidatesByJobCode(jobCode);

            if (appliedCandidates == null || appliedCandidates.Count == 0)
            {
                return NotFound("No matching candidates found.");
            }

            return Ok(appliedCandidates);
        }
        [HttpGet("GetAppliedCandidatesWithDetails/{jobCode}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetAppliedCandidateWithDetails(int jobCode)
        {
            var appliedCandidates = _blManager.JobBLManager.GetAppliedCandidatesWithCandidatesByJobCode(jobCode);

            if (appliedCandidates == null || appliedCandidates.Count == 0)
            {
                return NotFound("No matching candidates found.");
            }

            return Ok(appliedCandidates);
        }

        [HttpGet("GetJobsForCompany")]
        [Authorize(Roles = "Company")]
        public IActionResult GetJobsForCompany()
        {
            int companyId = GetUserIdFromToken();
            var companyJobs = _blManager.JobBLManager.GetCompanyJobs(companyId);
            if (companyJobs == null || companyJobs.Count == 0)
            {
                return NotFound("No Jobs for this company found.");
            }

            return Ok(companyJobs);
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