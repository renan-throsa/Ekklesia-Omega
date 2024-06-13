using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ekklesia.Api.Controllers
{
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
