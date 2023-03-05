using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Core.Events
{
    public class UpdatedEvent : BaseEvent, MediatR.INotification
    {
        public UpdatedEvent(EventSourceEnum source, object payload)
            : base ("UPDATED", source.ToString(), payload)
        {
        }
    }
}