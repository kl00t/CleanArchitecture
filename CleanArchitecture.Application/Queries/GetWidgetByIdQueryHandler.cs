using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Queries;

public record GetWidgetByIdQuery(Guid WidgetId) : IRequest<WidgetEntity>;
public class GetWidgetByIdQueryHandler(IWidgetRepository widgetRepository)
    : IRequestHandler<GetWidgetByIdQuery, WidgetEntity>
{
    public async Task<WidgetEntity> Handle(GetWidgetByIdQuery request, CancellationToken cancellationToken)
    {
        return await widgetRepository.GetWidgetByIdAsync(request.WidgetId);
    }
}