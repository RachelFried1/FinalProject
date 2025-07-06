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

        
    }
}
