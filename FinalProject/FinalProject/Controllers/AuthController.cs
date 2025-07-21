using API.DTO;
using BL;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBlManager _blManager;

        public AuthController(IBlManager blManager)
        {
            _blManager = blManager;
        }

        [HttpPost("SignUpJobSeeker")]
        public IActionResult SignUpJobSeeker([FromBody] JobSeekerBL seeker, [FromQuery] string password)
        {
            try
            {
<<<<<<< HEAD
                var jobSeeker = _mapper.Map<JobSeekerBL>(request);
                jobSeeker.IsActive = true;
                var token = _blManager.AuthManager.SignUpJobSeeker(jobSeeker, request.Password);
=======
                var token = _blManager.AuthManager.SignUpJobSeeker(seeker, password);
>>>>>>> b30581dcf064fb04ced3d8fd221c8ae4a56cff17
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SignUpCompany")]
        public IActionResult SignUpCompany([FromBody] CompanyBL company, [FromQuery] string password)
        {
            try
            {
<<<<<<< HEAD
                var company = _mapper.Map<CompanyBL>(request);
                var token = _blManager.AuthManager.SignUpCompany(company, request.Password);
=======
                var token = _blManager.AuthManager.SignUpCompany(company, password);
>>>>>>> b30581dcf064fb04ced3d8fd221c8ae4a56cff17
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SignInJobSeeker")]
        public IActionResult SignInJobSeeker([FromBody] SignInRequestDTO request)
        {
            try
            {
                var token = _blManager.AuthManager.SignInJobSeeker(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SignInCompany")]
        public IActionResult SignInCompany([FromBody] SignInRequestDTO request)
        {
            try
            {
                var token = _blManager.AuthManager.SignInCompany(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}