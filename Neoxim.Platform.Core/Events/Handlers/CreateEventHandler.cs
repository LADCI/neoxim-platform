using System.Text.Json;
using Neoxim.Platform.Core.Helpers;

namespace Neoxim.Platform.Core.Events.Handlers;

public class CreateEventHandler : MediatR.INotificationHandler<CreatedEvent>
{
    public async Task Handle(CreatedEvent notification, CancellationToken cancellationToken)
    {
        var payload  = JsonSerializer.Serialize(notification, JsonHelper.SerializerOptions);

        //.. Log here
        await Task.Delay(500, cancellationToken);

        Console.WriteLine(payload);
    }
}
