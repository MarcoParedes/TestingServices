using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorization = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorization) || authorization.ToString().Split(" ")[0].ToLower() != "bearer" || string.IsNullOrEmpty(authorization.ToString().Split(" ")[1]))
                throw new Exception("Debe ingresar un token válido para realizar esta operación.");

            string token = authorization.ToString().Split(" ")[1];

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken tokenS = handler.ReadToken(token) as JwtSecurityToken;

            DateTime fin = tokenS.Payload.ValidTo;

            var jti = tokenS.Claims.First(claim => claim.Type == "jti").Value;
            var roles = tokenS.Claims.Where(r => r.Type == ClaimTypes.Role).ToList();

            if (DateTime.Now > fin)
                throw new Exception("El token ha expirado.");

        }
    }
}
