using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces;

public interface IWidgetRepository
{
    Task<IEnumerable<WidgetEntity>> GetWidgets();
    Task<WidgetEntity> GetWidgetByIdAsync(Guid id);
    Task<WidgetEntity> AddWidgetAsync(WidgetEntity entity);
    Task<WidgetEntity> UpdateWidgetAsync(Guid widgetId, WidgetEntity entity);
    Task<bool> DeleteWidgetAsync(Guid widgetId);
}