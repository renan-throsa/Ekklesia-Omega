using Asp.Versioning;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ekklesia.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ApiController : ControllerBase
    {
        protected ActionResult<Response> ErrorResponse(Response result)
        {
            switch (result.Status)
            {
                case ResponseStatus.BadRequest:
                    return BadRequest(result);

                case ResponseStatus.NotFound:
                    return NotFound(result);

                case ResponseStatus.Unauthorized:
                    return Unauthorized(result);

                case ResponseStatus.Conflict:
                    return Conflict(result);

                default:
                    return BadRequest(result);
            }
        }
    }
}
