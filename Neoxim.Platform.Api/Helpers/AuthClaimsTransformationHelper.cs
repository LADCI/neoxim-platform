using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Neoxim.Platform.Api.Helpers
{
    public class AuthClaimsTransformationHelper : IClaimsTransformation
    {
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // var customClaims = await _dbContext
            //     .MyTableWithCustomClaims
            //     .Where(x => x.Username = principal.Identity.Name)
            //     .ToArrayAsync();

            var clone = principal.Clone();
            var identity = (ClaimsIdentity)clone.Identity;

            // foreach (var customClaim in customClaims)
            // {
            //     identity.AddClaim(new Claim(customClaim.Type, customClaim.Value));
            // }

            identity.AddClaim(new Claim("license", "premium"));
            identity.AddClaim(new Claim("subscription", "active"));

            return clone;
        }
    }
}