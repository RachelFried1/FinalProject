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

        //[HttpPost]
        //[Route("AddJobOffersForSeeker")]
        //public IActionResult AddJobOffersForSeeker([FromBody] JobSeekerBL jobSeekerBL)
        //{
        //    if (jobSeekerBL == null)
        //    {
        //        return BadRequest("Invalid job seeker data.");
        //    }

        //    _blManager.JobSeekerBLManager.AddJobOffersForSeeker(jobSeekerBL);
        //    return Ok($"offers for Job seeker:{jobSeekerBL.Id} were added successfully.");
        //}

        [HttpGet("FindMatchingJobs/{id}")]
        public IActionResult FindMatchingJobs(int id)
        {
            var matchingJobs = _blManager.JobSeekerBLManager.GetJobOffersBySeekerId(id);

            //maybe only check in react program:
            if (matchingJobs == null || matchingJobs.Count == 0)
            {
                return NotFound("No matching jobs found.");
            }
            return Ok(matchingJobs);
        }

        [HttpPut("Activate/{id}")]
        public IActionResult Activate(int id)
        {
            _blManager.JobSeekerBLManager.Activate(id);
            return Ok($"Job Seeker {id} has been activated.");
        }

        [HttpPut("Deactivate/{id}")]

        public IActionResult DeActivate(int id)
        {
            _blManager.JobSeekerBLManager.NoLongerActive(id);
            return Ok($"Job Seeker {id} has been deactivated.");
        }
        [HttpPut("ApplyForJOb/{id}")]
        public IActionResult ApplyForJOb(int offerCode)
        {
            _blManager.JobSeekerBLManager.ApplyForOffer(offerCode);
            return Ok($"application for offer {offerCode} successfull.");
        }

    }
}
