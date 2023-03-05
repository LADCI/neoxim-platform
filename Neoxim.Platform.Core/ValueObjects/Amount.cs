using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Enums;

namespace Neoxim.Platform.Core.ValueObjects
{
    public class Amount
    {
        public decimal Value { get; set; }
        public CurrencyEnum Currency { get; set; }
    }
}