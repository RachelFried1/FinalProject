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
                return BadRequest("Invalid job data.");
            }

            _blManager.JobBLManager.AddJob(job);
            return Ok($"Job: {job.Code} was added successfully.");
        }
        //[HttpPost]
        //[Route("AddJoboffersForJobs")]
        //public IActionResult AddJobOffersForJOb([FromBody] JobBL job)
        //{
        //    if (job == null)
        //    {
        //        return BadRequest("Invalid job data.");
        //    }

        //    _blManager.JobBLManager.AddJobOffersForJob(job);
        //    return Ok($"Job offers for: {job.Code} were added successfully.");
        //}

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
        [HttpGet("GetAppliedCandidates/{jobCode}")]
        public IActionResult GetAppliedCandidate(int code)
        {
            return Ok(_blManager.JobBLManager.GetAppliedCandidatesByJobCode(code));
        }
        [HttpGet("GetJobsForCompany/{companyCode}")]
        public IActionResult GetJobsForCompany(int companyCode)
        {
            return Ok(_blManager.JobBLManager.GetCompanyJobs(companyCode));
        }

        [HttpDelete("NotSeekingWorkers/{code}")]
        public IActionResult NotSeekingWorkers(int code)
        {
            _blManager.JobBLManager.NotSeekingWorkers(code);
            return Ok($"Job : {code} is no longer seeking workers.");
        }

        


    }
}
