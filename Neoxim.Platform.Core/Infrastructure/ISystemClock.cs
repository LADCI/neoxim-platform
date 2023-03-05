using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoxim.Platform.Core.Infrastructure
{
    public interface ISystemClock
    {
        public DateTimeOffset UtcNow { get; }
    }
}