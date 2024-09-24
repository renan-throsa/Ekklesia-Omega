using Asp.Versioning;
using Ekklesia.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ekklesia.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Authorize]
    public class BaseController : ControllerBase
    {        

        protected ActionResult CustomResponse(OperationResultModel result)
        {

            if (!result.IsValid)
            {
                return ErrorResponse(result);
            }

            return Ok(result.Content);
        }

        protected ActionResult ErrorResponse(OperationResultModel result)
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(result.Content);

                case HttpStatusCode.NotFound:
                    return NotFound(result.Content);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(result.Content);

                case HttpStatusCode.Conflict:
                    return Conflict(result.Content);

                default:
                    return BadRequest(result.Content);
            }
        }
    }
}
