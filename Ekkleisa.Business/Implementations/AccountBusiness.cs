
using AutoMapper;
using Ekklesia.Application.Abstractions;
using Ekklesia.Application.Models;
using Ekklesia.Application.Validations;
using Ekklesia.Domain.DTOs;
using Ekklesia.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Ekklesia.Application.Implementations
{
    public class AccountBusiness : BaseBusiness, IAccountBusiness
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SecutitySettings _appSettings;
        protected readonly ILogger<IAccountBusiness> _logger;

        public AccountBusiness(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<SecutitySettings> appSettings, ILogger<IAccountBusiness> logger, IMapper mapper) : base(mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public async Task<OperationResultModel> SignIn(SignInModel model)
        {
            _logger.LogInformation($"Logging sign in for: {model.Email}");

            if (!ModelIsValid(new SignInValidation(), model))
                return Error();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
                return Error($"Usuário {model.Email} não encontrado", HttpStatusCode.NotFound);

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: true);

            if (result.IsLockedOut)
                return Error($"Usuário bloquado por tentativas inválidas. Bloqueio temina às {user.LockoutEnd}", HttpStatusCode.BadRequest);

            if (!result.Succeeded)
                return Error($"Usuário ou senha incorreto. Tentativas Restantes: {_appSettings.MaxFailedAccessAttempts - user.AccessFailedCount}", HttpStatusCode.BadRequest);


            await _signInManager.SignInAsync(user, isPersistent: model.RememberMe);

            return Success(await GetToken(user));
        }

        public async Task<OperationResultModel> SignUp(SignUpModel model)
        {
            _logger.LogInformation($"Logging sign up for: {model.Email}");

            if (!ModelIsValid(new SignUpValidation(), model))
                return Error();
            

            var user = new IdentityUser
            {
                UserName = model.Name,
                PhoneNumber = model.Phone,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return Error(HttpStatusCode.BadRequest);

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Success(await GetToken(user));
        }

        private Response Response(HttpStatusCode status, object result = null)
        {
            return
            new Response
            {
                Status = status,
                Payload = result
            };
        }

        private async Task<string> GetToken(IdentityUser user)
        {
            var secretKey = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName),

                });

            var permissoes = await _userManager.GetClaimsAsync(user);

            claims.AddClaims(permissoes);

            return new JwtSecurityTokenHandler().CreateEncodedJwt(
                new SecurityTokenDescriptor
                {
                    Issuer = _appSettings.Issuer,
                    Audience = _appSettings.Audience,
                    NotBefore = DateTime.Now,
                    Expires = DateTime.Now.AddHours(_appSettings.ExpirationInHours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
                    Subject = claims
                });


        }
    }
}
