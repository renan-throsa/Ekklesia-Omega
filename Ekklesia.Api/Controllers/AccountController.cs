
using Ekklesia.Application.Abstractions;
using Ekklesia.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IAccountBusiness _accountBusiness;

        public AccountController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            var result = await _accountBusiness.SignUp(model);
            return CustomResponse(result);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            var result = await _accountBusiness.SignIn(model);
            return CustomResponse(result);

        }
    }
}
