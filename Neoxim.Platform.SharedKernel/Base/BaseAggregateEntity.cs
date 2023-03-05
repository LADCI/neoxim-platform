using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoxim.Platform.SharedKernel.Base
{
    public abstract class BaseAggregateEntity : BaseEntity
    {
        protected BaseAggregateEntity()
        {
            Events = new List<BaseEvent>();
        }

        public IList<BaseEvent> Events { get; set; }
    }
}