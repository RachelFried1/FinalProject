using API.DTO;
using BL;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

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

        [HttpPost("SignUpJobSeeker")]
        public IActionResult SignUpJobSeeker([FromBody] JobSeekerSignUpRequestDTO seeker)
        {
            try
            {
                var seekerBL = _mapper.Map<JobSeekerBL>(seeker);

                var token = _blManager.AuthManager.SignUpJobSeeker(seekerBL, seeker.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SignUpCompany")]
        public IActionResult SignUpCompany([FromBody] CompanySignUpRequestDTO company)
        {
            try
            {
                var companyBL = _mapper.Map<CompanyBL>(company);
                var token = _blManager.AuthManager.SignUpCompany(companyBL, company.Password);
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