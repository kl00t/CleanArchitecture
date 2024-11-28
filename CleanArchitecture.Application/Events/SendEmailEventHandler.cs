using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Events;

public class SendEmailEventHandler
    (ILogger<SendEmailEventHandler> logger)
    : INotificationHandler<WidgetCreatedEvent>
{
    public async Task Handle(WidgetCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Widget created: Send mail start for {UserId}", notification.WidgetId);

        await Task.Delay(2000, cancellationToken);

        logger.LogInformation("Widget created: Send mail done for {UserId}", notification.WidgetId);
    }
}