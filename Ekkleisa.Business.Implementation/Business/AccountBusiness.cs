using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ekkleisa.Business.Implementation.Business
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInValidation _signInValidation;
        private readonly SignUpValidation _signUpValidation;
        private readonly SecutitySettings _appSettings;
        protected readonly ILogger<IAccountBusiness> _logger;

        public AccountBusiness(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            SignUpValidation signUpValidation,
            SignInValidation signInValidation,
            IOptions<SecutitySettings> appSettings,
            ILogger<IAccountBusiness> logger)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._signUpValidation = signUpValidation;
            this._signInValidation = signInValidation;
            this._appSettings = appSettings.Value;
            this._logger = logger;
        }

        public async Task<Response> SignIn(SignInDTO Dto)
        {
            _logger.LogInformation($"Logging sign in for: {Dto.Email}");
            var modelState = _signInValidation.Validate(Dto);

            if (!modelState.IsValid) return Response(ResponseStatus.BadRequest, modelState.Errors.Select(x => x.ErrorMessage));

            var user = await _userManager.FindByEmailAsync(Dto.Email);

            if (user is null) return Response(ResponseStatus.NotFound, $"Usuário {Dto.Email} não encontrado");

            var result = await _signInManager.PasswordSignInAsync(user, Dto.Password, isPersistent: false, lockoutOnFailure: true);
            if (result.IsLockedOut) return Response(ResponseStatus.BadRequest, $"Usuário bloquado por tentativas inválidas. Bloqueio temina às {user.LockoutEnd}");
            if (!result.Succeeded) return Response(ResponseStatus.BadRequest, $"Usuário ou senha incorreto. Tentativas Restantes: {_appSettings.MaxFailedAccessAttempts - user.AccessFailedCount}");


            await _signInManager.SignInAsync(user, isPersistent: Dto.RememberMe);
            var claims = await _userManager.GetClaimsAsync(user);
            var token = GetToken(user, claims);
            return Response(ResponseStatus.Ok, token);
        }

        public async Task<Response> SignUp(SignUpDTO Dto)
        {
            _logger.LogInformation($"Logging sign up for: {Dto.Email}");
            var modelState = _signUpValidation.Validate(Dto);
            if (!modelState.IsValid) return Response(ResponseStatus.BadRequest, modelState.Errors.Select(x => x.ErrorMessage));

            var user = new IdentityUser
            {
                UserName = Dto.Name,
                PhoneNumber = Dto.Phone,
                Email = Dto.Email,
            };

            var result = await _userManager.CreateAsync(user, Dto.Password);
            if (!result.Succeeded) return Response(ResponseStatus.Ok, result.Errors.Select(x => x.Description));

            await _signInManager.SignInAsync(user, isPersistent: false);
            var claims = await _userManager.GetClaimsAsync(user);
            var token = GetToken(user, claims);
            return Response(ResponseStatus.Ok, token);
        }

        private Response Response(ResponseStatus status, object result = null)
        {
            return
            new Response
            {
                Status = status,
                Payload = result
            };
        }

        private TokenDTO GetToken(IdentityUser user, IList<Claim> claims)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = new JwtSecurityToken(
                issuer: _appSettings.Issuer,
                audience: _appSettings.Audience,
                claims: this.GetClaims(user, claims),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(_appSettings.ExpirationInHours),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );

            var encodedToken = (new JwtSecurityTokenHandler()).WriteToken(token);

            return new TokenDTO
            {
                User = new UserDTO(user.UserName, user.Email, user.PhoneNumber),
                Token = encodedToken,
                ExpiresAt = DateTime.UtcNow.AddHours(_appSettings.ExpirationInHours)
            };

        }

        private IList<Claim> GetClaims(IdentityUser user, IList<Claim> claims)
        {

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            return claims;
        }
    }
}
