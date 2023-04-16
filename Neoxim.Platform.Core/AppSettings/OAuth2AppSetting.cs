using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoxim.Platform.Core.AppSettings
{
    public class OAuth2AppSetting
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}