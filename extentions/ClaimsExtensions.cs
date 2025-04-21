using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace webapi.extentions
{
    public static class ClaimsExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            var claim = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.GivenName);

            if (claim == null)
                throw new Exception("Claim 'GivenName' Not Found on token.");

            return claim.Value;
        }
    }
}