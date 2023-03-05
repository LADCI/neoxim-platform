using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Core.ValueObjects
{
    public class UserName : BaseValueObject
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public GenderEnum Gender { get; protected set; }
    }
}