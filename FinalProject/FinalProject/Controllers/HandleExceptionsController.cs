using DAL.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HandleExceptionsController : ControllerBase
    {
        [HttpGet("/error")]
        [HttpPost("/error")]
        [HttpPut("/error")]
        [HttpDelete("/error")]
        public ActionResult HandleError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionDetails?.Error is SeekerNotFoundException seekerNotFound)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Seeker not found!",
                statusCode: seekerNotFound.StatusCode
                );
            }
            if (exceptionDetails?.Error is SeekerAlreadyExistsException seekerAlreadyExists)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Seeker already exists!",
                statusCode: seekerAlreadyExists.StatusCode
                );
            }
            if (exceptionDetails?.Error is JobNotFoundException jobNotFound)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Job not found!",
                statusCode: jobNotFound.StatusCode
                );
            }
            if (exceptionDetails?.Error is JobAlreadyExistsException jobAlreadyExists)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Job already exists!",
                statusCode: jobAlreadyExists.StatusCode
                );
            }
            if (exceptionDetails?.Error is CompanyNotFoundException companyNotFound)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Job already exists!",
                statusCode: companyNotFound.StatusCode
                );
            }
            if (exceptionDetails?.Error is CompanyAlreadyExistsException companyAlreadyExists)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Job already exists!",
                statusCode: companyAlreadyExists.StatusCode
                );
            }
            if (exceptionDetails?.Error is SeekerAlreadyActiveException seekerAlreadyActive)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Job already exists!",
                statusCode: seekerAlreadyActive.StatusCode
                );
            }
            if (exceptionDetails?.Error is SeekerNotActiveException seekerNotActive)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Job already exists!",
                statusCode: seekerNotActive.StatusCode
                );
            }
            if (exceptionDetails?.Error is SeekerAlreadyAppliedException seekerAlreadyApplied)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Job already exists!",
                statusCode: seekerAlreadyApplied.StatusCode
                );
            }
            if (exceptionDetails?.Error is SeekerNotAppliedException seekerNotApplied)
            {
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Job already exists!",
                statusCode: seekerNotApplied.StatusCode
                );
            }
            return Problem(
                detail: "Unexpected error! try to restart the website...",
                title: "An error occurred",
                statusCode: 500
            );
        }
    }
}
