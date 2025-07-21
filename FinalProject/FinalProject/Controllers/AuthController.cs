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
        public IActionResult SignUpJobSeeker([FromBody] JobSeekerSignUpRequestDTO request)
        {
            try
            {
                // Map DTO to BL model
                var seeker = new JobSeekerBL
                {
                    Id = request.Id,
                    Name = request.Name,
                    SirName = request.SirName,
                    Email = request.Email,
                    Country = request.Country,
                    DailyWorkHours = request.DailyWorkHours,
                    YearsOfExperience = request.YearsOfExperience,
                    HasDegree = request.HasDegree,
                    Field = request.Field
                };
                var token = _blManager.AuthManager.SignUpJobSeeker(seeker, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SignUpCompany")]
        public IActionResult SignUpCompany([FromBody] CompanySignUpRequestDTO request)
        {
            try
            {
                // Map DTO to BL model
                var company = new CompanyBL
                {
                    Code = request.Code,
                    Name = request.Name,
                    Email = request.Email,
                    Rate = request.Rate
                };
                var token = _blManager.AuthManager.SignUpCompany(company, request.Password);
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