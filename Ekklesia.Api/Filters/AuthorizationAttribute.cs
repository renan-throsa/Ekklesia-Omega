using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Ekklesia.Api.Filters
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _claim;

        public AuthorizationAttribute(string Claim) => _claim = Claim;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var c = user.Claims.ToList();
            if (user.Identity.IsAuthenticated && user.HasClaim("permissions", _claim))
            {
                return;
            }

            context.Result = new ForbidResult();

        }
    }
}
