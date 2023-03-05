using Neoxim.Platform.Core.Enums;
using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Core.Events
{
    public class AuditActionEvent : BaseEvent, MediatR.INotification
    {
        public AuditActionEvent(AuditActionTypeEnum action, EventSourceEnum source, object payload, string author)
            : base ("AUDIT", source.ToString(), payload)
        {
            Action = action;
            Author = author;
        }

        public AuditActionTypeEnum Action { get; protected set; }
        public string Author { get; protected set; }
    }
}