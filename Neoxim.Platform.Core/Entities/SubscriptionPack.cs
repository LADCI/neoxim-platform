using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.ValueObjects;

namespace Neoxim.Platform.Core.Entities
{
    public class SubscriptionPack
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public Amount Amount { get; protected set; }
    }
}