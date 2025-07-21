using BL;
using BL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Company")]
    public class CompanyController : ControllerBase
    {
        private IBlManager _blManager;
        public CompanyController(IBlManager blManager)
        {
            _blManager = blManager;
        }

        private int GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("GetCompanyById")]
        public IActionResult GetCompanyById()
        {
            int companyId = GetUserIdFromToken();
            var company = _blManager.CompanyBLManager.GetCompanyById(companyId);
            if (company == null)
                return NotFound($"Company with id {companyId} not found.");
            return Ok(company);
        }
    }
}