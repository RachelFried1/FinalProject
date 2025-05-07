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
        [HttpPost]
        [Route("AddJobSeeker")]
        public IActionResult AddJobSeeker([FromBody] JobSeekerBL jobSeeker)
        {
            if (jobSeeker == null)
            {
                return BadRequest("Invalid job seeker data.");
            }
            try
            {
                _blManager.JobSeekerBLManager.AddJobSeeker(jobSeeker);
                return Ok("Job seeker added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding job seeker: {ex.Message}");
            }
        }
    }
}
