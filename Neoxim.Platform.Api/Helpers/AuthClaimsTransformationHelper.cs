using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Neoxim.Platform.Core.Entities;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.Core.Services;

namespace Neoxim.Platform.Api.Helpers
{
    /// <summary>
    /// Claim transformer
    /// </summary>
    public class AuthClaimsTransformationHelper : IClaimsTransformation
    {
        private readonly IUserService _userService;
        private readonly ITenantService _tenantService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="tenantService"></param>
        public AuthClaimsTransformationHelper(IUserService userService, ITenantService tenantService)
        {
            _userService = userService;
            _tenantService = tenantService;
        }

        /// <summary>
        /// Transform claims
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // var user = await _userService.GetAsync(Guid.Parse(principal.Claims.First(x => x.Type == "sub").Value), default);
            // var tenant = await _tenantService.GetAsync(Guid.Parse(principal.Claims.First(x => x.Type == GetCustomClaimType("tenant_id")).Value), default);

            // for test only
            var user = await _userService.GetAsync(Guid.Parse("b06502de-1fd2-4dfc-9ffe-f49ba3a34981"), default);
            var tenant = await _tenantService.GetAsync(Guid.Parse("57c7a229-6624-4098-bfb7-8edccf5cef11"), default);
            // end

            var clone = principal.Clone();

            if (clone.Identity is ClaimsIdentity identity)
            {
                if (user.Claims.Any(x => x.name.Equals(nameof(TenantClaimEnum.ADMIN), StringComparison.OrdinalIgnoreCase)))
                {
                    tenant.Claims.ToList().ForEach(c => identity.AddClaim(new Claim(GetCustomClaimType(c.Name), c.Name)));
                }
                else
                {
                    foreach (var customClaim in user.Claims)
                    {
                        identity.AddClaim(new Claim(GetCustomClaimType(customClaim.name), customClaim.name));
                    }
                }

                identity.AddClaim(new Claim(GetCustomClaimType("user_id"), user.Id.ToString()));
                identity.AddClaim(new Claim(GetCustomClaimType("user_name"), $"{user.FirstName} {user.LastName}"));
                identity.AddClaim(new Claim(GetCustomClaimType("user_gender"), user.Gender.ToString()));
                identity.AddClaim(new Claim(GetCustomClaimType("tenant_id"), tenant.Id.ToString()));
                identity.AddClaim(new Claim(GetCustomClaimType("tenant_name"), tenant.Name));

                identity.AddClaim(new Claim(GetCustomClaimType("tenant_subscription/status"), tenant.HasActiveSubscription ? "active" : "idle"));
            }

            return clone;
        }

        private static string GetCustomClaimType(string claimName)
        {
            return $"neoxim/claims/{claimName.ToLower()}";
        }
    }
}