using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record DeleteWidgetCommand(Guid WidgetId) : IRequest<bool>;

internal class DeleteWidgetCommandHandler(IWidgetRepository widgetRepository)
    : IRequestHandler<DeleteWidgetCommand, bool>
{
    public async Task<bool> Handle(DeleteWidgetCommand request, CancellationToken cancellationToken)
    {
        return await widgetRepository.DeleteWidgetAsync(request.WidgetId);
    }
}