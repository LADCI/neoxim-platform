using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Core.Events
{
    public class DeletedEvent : BaseEvent, MediatR.INotification
    {
        public DeletedEvent(EventSourceEnum source, object payload)
            : base ("DELETED", source.ToString(), payload)
        {
        }
    }
}