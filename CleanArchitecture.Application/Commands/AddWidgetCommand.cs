using CleanArchitecture.Application.Events;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record AddWidgetCommand(WidgetEntity Widget) : IRequest<WidgetEntity>;

public class AddEmployeeCommandHandler(IWidgetRepository widgetRepository, IPublisher mediator)
    : IRequestHandler<AddWidgetCommand, WidgetEntity>
{
    public async Task<WidgetEntity> Handle(AddWidgetCommand request, CancellationToken cancellationToken)
    {
        var widget = await widgetRepository.AddWidgetAsync(request.Widget);
        await mediator.Publish(new WidgetCreatedEvent(widget.Id), cancellationToken);
        return widget;
    }
}