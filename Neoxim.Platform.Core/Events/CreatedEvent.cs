using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Core.Events
{
    public class CreatedEvent : BaseEvent, MediatR.INotification
    {
        public CreatedEvent(EventSourceEnum source, object payload)
            : base ("CREATED", source.ToString(), payload)
        {
        }
    }
}