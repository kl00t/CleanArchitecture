using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record UpdateWidgetCommand(Guid WidgetId, WidgetEntity Widget)
        : IRequest<WidgetEntity>;
public class UpdateWidgetCommandHandler(IWidgetRepository employeeRepository)
    : IRequestHandler<UpdateWidgetCommand, WidgetEntity>
{
    public async Task<WidgetEntity> Handle(UpdateWidgetCommand request, CancellationToken cancellationToken)
    {
        return await employeeRepository.UpdateWidgetAsync(request.WidgetId, request.Widget);
    }
}