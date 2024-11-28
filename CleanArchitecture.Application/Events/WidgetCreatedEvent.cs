using MediatR;

namespace CleanArchitecture.Application.Events;

public record WidgetCreatedEvent(Guid WidgetId) : INotification;