using BL;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IBlManager _blManager;
        public CompanyController(IBlManager blManager)
        {
            _blManager = blManager;
        }
        [HttpGet("GetCompanyById/{id}")]
        public IActionResult GetCompanyById(int id)
        {
            return Ok(_blManager.CompanyBLManager.GetCompanyById(id));
        }

        [HttpPost]
        [Route("AddCompany")]
        public IActionResult AddCompany([FromBody] CompanyBL company)
        {
            if (company == null)
            {
                return BadRequest("Invalid company data.");
            }

            _blManager.CompanyBLManager.AddCompany(company);
            return Ok($"Company: {company.Code} was added successfully.");
        }
    }
}
