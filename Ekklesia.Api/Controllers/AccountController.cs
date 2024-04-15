using Asp.Versioning;
using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBusiness _accountBusiness;

        public AccountController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<Response>> SignUp(SignUpDTO Dto)
        {
            var response = await _accountBusiness.SignUp(Dto);
            if (response.status == ResponseStatus.Ok) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<Response>> SignIn(SignInDTO Dto)
        {
            var response = await _accountBusiness.SignIn(Dto);
            if (response.status == ResponseStatus.Ok) return Ok(response);
            return BadRequest(response);
        }
    }
}
