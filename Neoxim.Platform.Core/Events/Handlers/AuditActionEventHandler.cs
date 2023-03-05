using System.Text.Json;
using Neoxim.Platform.Core.Helpers;

namespace Neoxim.Platform.Core.Events.Handlers
{
    public class AuditActionEventHandler : MediatR.INotificationHandler<AuditActionEvent>
    {
        public async Task Handle(AuditActionEvent notification, CancellationToken cancellationToken)
        {
            var payload  = JsonSerializer.Serialize(notification, JsonHelper.SerializerOptions);

            //.. Log here
            await Task.Delay(500, cancellationToken);

            Console.WriteLine(payload);
        }
    }
}