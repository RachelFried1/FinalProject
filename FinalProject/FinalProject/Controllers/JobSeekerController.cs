using BL;
using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "JobSeeker")]
    public class JobSeekerController : ControllerBase
    {
        private IBlManager _blManager;
        public JobSeekerController(IBlManager blManager)
        {
            _blManager = blManager;
        }

        private int GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("GetJobSeekerById")]
        public IActionResult GetJobSeekerById()
        {
            int jobSeekerId = GetUserIdFromToken();
            var jobSeeker = _blManager.JobSeekerBLManager.GetJobSeekerById(jobSeekerId);
            if (jobSeeker == null)
                return NotFound($"Job seeker with id {jobSeekerId} not found.");
            return Ok(jobSeeker);
        }

        [HttpGet("FindMatchingJobs")]
        public IActionResult FindMatchingJobs()
        {
            int jobSeekerId = GetUserIdFromToken();
            var matchingJobs = _blManager.JobSeekerBLManager.GetJobOffersBySeekerId(jobSeekerId);
            if (matchingJobs == null || matchingJobs.Count == 0)
            {
                return NotFound("No matching jobs found.");
            }
            return Ok(matchingJobs);
        }


        [HttpGet("FindMatchingJobsDetailed")]
        public IActionResult GetJobOffersWithJobsForSeeker()
        {
            int jobSeekerId = GetUserIdFromToken();
            var matchingJobs = _blManager.JobSeekerBLManager.GetJobOffersWithJobsBySeekerId(jobSeekerId);
            if (matchingJobs == null || matchingJobs.Count == 0)
            {
                return NotFound("No matching jobs found.");
            }
            return Ok(matchingJobs);
        }

        [HttpPut("Activate")]
        public IActionResult Activate()
        {
            int jobSeekerId = GetUserIdFromToken();
            _blManager.JobSeekerBLManager.Activate(jobSeekerId);
            return Ok($"Job Seeker {jobSeekerId} has been activated.");
        }


        [HttpPut("Activate")]
        public IActionResult Activate()
        {
            int jobSeekerId = GetUserIdFromToken();
            _blManager.JobSeekerBLManager.Activate(jobSeekerId);
            return Ok($"Job Seeker {jobSeekerId} has been activated.");
        }

        [HttpPut("Deactivate")]
        public IActionResult DeActivate()
        {
            int jobSeekerId = GetUserIdFromToken();
            _blManager.JobSeekerBLManager.NoLongerActive(jobSeekerId);
            return Ok($"Job Seeker {jobSeekerId} has been deactivated.");
        }

        [HttpPut("ApplyForJob/{offerCode}")]
        public IActionResult ApplyForJob(int offerCode)
        {
            _blManager.JobSeekerBLManager.ApplyForOffer(offerCode);
            return Ok($"Application for offer {offerCode} successful.");
        }
    }
}