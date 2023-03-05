//using Microsoft.Extensions.Internal;
using Neoxim.Platform.Core.Infrastructure;

namespace Neoxim.Platform.Infrastructure.Systems
{
    public class SystemClock : ISystemClock
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}