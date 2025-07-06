using API.DTO;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthController(IBlManager blManager, IMapper mapper)
        {
            _blManager = blManager;
            _mapper = mapper;
        }

        [HttpPost("signup/jobseeker")]

        public IActionResult SignUpJobSeeker([FromBody] JobSeekerSignUpRequestDTO request)
        {
            try
            {
                var jobSeeker = _mapper.Map<JobSeekerBL>(request);
                jobSeeker.IsActive = true;
                _blManager.AuthManager.SignUpJobSeeker(jobSeeker, request.Password);
                return Ok("Job seeker registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signup/company")]
        public IActionResult SignUpCompany([FromBody] CompanySignUpRequestDTO request)
        {
            try
            {
                var company = _mapper.Map<CompanyBL>(request);
                _blManager.AuthManager.SignUpCompany(company, request.Password);
                return Ok("Company registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] SignInRequestDTO request)
        {
            try
            {
                var token = _blManager.AuthManager.SignIn(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
