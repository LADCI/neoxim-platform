using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoxim.Platform.Api.Constants
{
    public class ClaimsConstant
    {
        public class Type
        {
            public const string ADMIN = "neoxim/claims/admin";
            public const string DOWNLOAD = "neoxim/claims/download";
            public const string UPLOAD = "neoxim/claims/upload";
            public const string WRITE = "neoxim/claims/write";
            public const string READ = "neoxim/claims/read";
            public const string SUBSCRIPTION_ACTIVE = "neoxim/claims/tenant_subscription/status";
        }

        public static class Value
        {
            public static string ADMIN = $"{Core.Enums.TenantClaimEnum.ADMIN}";
            public static string DOWNLOAD = $"{Core.Enums.TenantClaimEnum.DOWNLOAD}";
            public static string UPLOAD = $"{Core.Enums.TenantClaimEnum.UPLOAD}";
            public static string WRITE = $"{Core.Enums.TenantClaimEnum.WRITE}";
            public static string READ = $"{Core.Enums.TenantClaimEnum.READ}";
            public static string SUBSCRIPTION = $"active";
        }

        public static class Scopes
        {
            public static IDictionary<string, string> Dico = new Dictionary<string, string>
                    {
                        { "openid" , "OpenId" },
                        { "profile" , "Profile" },
                        { "email" , "Email" },
                        { "offline_access" , "Offline Access" },
                        { "api" , "Neoxim.Platform.Api" }
                    };
        }
    }
}