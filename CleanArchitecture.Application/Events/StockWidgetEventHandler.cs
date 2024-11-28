using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Events;

public class StockWidgetEventHandler
    (ILogger<StockWidgetEventHandler> logger)
    : INotificationHandler<WidgetCreatedEvent>
{
    public async Task Handle(WidgetCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Widget created: {UserId}", notification.WidgetId);

        await Task.Delay(2000, cancellationToken);

        logger.LogInformation("Widget created: {UserId}", notification.WidgetId);
    }
}