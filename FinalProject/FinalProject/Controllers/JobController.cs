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

        [HttpGet("FindMatchingJobs/{id}")]
        public IActionResult FindMatchingJobs(int id)
        {
            var matchingJobs = _blManager.JobSeekerBLManager.FindMatchingJobs(id);

            //maybe only check in react program:
            if (matchingJobs == null || matchingJobs.Count == 0)
            {
                return NotFound("No matching jobs found.");
            }
            return Ok(matchingJobs);
        }

        //[HttpDelete("NotSeekingJob/{id}")]
        //public IActionResult NotSeekingJob(int id)
        //{
        //    _blManager.JobSeekerBLManager.NotSeekingJob(id);
        //    return Ok($"Job seeker: {id} is no longer seeking jobs.");
        //}
    }
}
