using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Queries;

public record GetAllWidgetsQuery() : IRequest<IEnumerable<WidgetEntity>>;
public class GetAllEmployeesQueryHandler(IWidgetRepository widgetRepository)
    : IRequestHandler<GetAllWidgetsQuery, IEnumerable<WidgetEntity>>
{
    public async Task<IEnumerable<WidgetEntity>> Handle(GetAllWidgetsQuery request, CancellationToken cancellationToken)
    {
        return await widgetRepository.GetWidgets();
    }
}