using BL.Models;
using BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AutoMapper;
using API.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IBlManager _blManager;
        private readonly IMapper _mapper;

        public JobController(IBlManager blManager, IMapper mapper)
        {
            _blManager = blManager;
            _mapper = mapper;
        }

        private int GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        private bool IsCompanyOwnerOfJob(int jobCode)
        {
            var job = _blManager.JobBLManager.GetJobByCode(jobCode);
            int companyId = GetUserIdFromToken();
            return job != null && job.CompanyId == companyId;
        }

        [HttpGet("GetJobByCode/{code}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetJobByCode(int code)
        {
            if (!IsCompanyOwnerOfJob(code))
                return Forbid();
            var job = _blManager.JobBLManager.GetJobByCode(code);
            if (job == null) return NotFound();
            return Ok(job);
        }

        [HttpPost("AddJob")]
        [Authorize(Roles = "Company")]
        public IActionResult AddJob([FromBody] AddJobDTO jobDto)
        {
            if (jobDto == null)
                return BadRequest("Invalid job data.");

            var jobBl = _mapper.Map<JobBL>(jobDto);
            jobBl.CompanyId = GetUserIdFromToken();

            _blManager.JobBLManager.AddJob(jobBl);
            return Ok($"Job: {jobBl.Code} was added successfully.");
        }

        [HttpGet("FindMatchingCandidates/{code}")]
        [Authorize(Roles = "Company")]
        public IActionResult FindMatchingCandidates(int code)
        {
            if (!IsCompanyOwnerOfJob(code))
                return Forbid();
            var matchingCandidates = _blManager.JobBLManager.GetJobOffersByJobCode(code);
            if (matchingCandidates == null || matchingCandidates.Count == 0)
                return NotFound("No matching candidates found.");
            return Ok(matchingCandidates);
        }

        [HttpGet("GetJobOffersWithCandidates/{jobCode}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetJobOffersWithCandidates(int jobCode)
        {
            if (!IsCompanyOwnerOfJob(jobCode))
                return Forbid();
            var offers = _blManager.JobBLManager.GetJobOffersWithCandidatesByJobCode(jobCode);
            if (offers == null || offers.Count == 0)
                return NotFound("No matching candidates found.");
            return Ok(offers);
        }

        [HttpGet("GetAppliedCandidates/{jobCode}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetAppliedCandidate(int jobCode)
        {
            if (!IsCompanyOwnerOfJob(jobCode))
                return Forbid();
            var appliedCandidates = _blManager.JobBLManager.GetAppliedCandidatesByJobCode(jobCode);
            if (appliedCandidates == null || appliedCandidates.Count == 0)
                return NotFound("No matching candidates found.");
            return Ok(appliedCandidates);
        }

        [HttpGet("GetAppliedCandidatesWithDetails/{jobCode}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetAppliedCandidateWithDetails(int jobCode)
        {
            if (!IsCompanyOwnerOfJob(jobCode))
                return Forbid();
            var appliedCandidates = _blManager.JobBLManager.GetAppliedCandidatesWithCandidatesByJobCode(jobCode);
            if (appliedCandidates == null || appliedCandidates.Count == 0)
                return NotFound("No matching candidates found.");
            return Ok(appliedCandidates);
        }

        [HttpGet("GetJobsForCompany")]
        [Authorize(Roles = "Company")]
        public IActionResult GetJobsForCompany()
        {
            int companyId = GetUserIdFromToken();
            var companyJobs = _blManager.JobBLManager.GetCompanyJobs(companyId);
            if (companyJobs == null || companyJobs.Count == 0)
                return NotFound("No Jobs for this company found.");
            return Ok(companyJobs);
        }

        [HttpDelete("NotSeekingWorkers/{code}")]
        [Authorize(Roles = "Company")]
        public IActionResult NotSeekingWorkers(int code)
        {
            if (!IsCompanyOwnerOfJob(code))
                return Forbid();
            _blManager.JobBLManager.NotSeekingWorkers(code);
            return Ok($"Job : {code} is no longer seeking workers.");
        }
    }
}