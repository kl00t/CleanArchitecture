using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class WidgetRepository(AppDbContext dbContext) : IWidgetRepository
{
    public async Task<IEnumerable<WidgetEntity>> GetWidgets()
    {
        return await dbContext.Widgets.ToListAsync();
    }

    public async Task<WidgetEntity> GetWidgetByIdAsync(Guid id)
    {
        var widget = await dbContext.Widgets.FirstOrDefaultAsync(x => x.Id == id);
        return widget is null ? throw new InvalidOperationException($"Widget with id {id} not found.") : widget;
    }

    public async Task<WidgetEntity> AddWidgetAsync(WidgetEntity entity)
    {
        entity.Id = Guid.NewGuid();
        dbContext.Widgets.Add(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<WidgetEntity> UpdateWidgetAsync(Guid widgetId, WidgetEntity entity)
    {
        var widget = await dbContext.Widgets.FirstOrDefaultAsync(x => x.Id == widgetId);

        if (widget is not null)
        {
            widget.Name = entity.Name;
            widget.Description = entity.Description;

            await dbContext.SaveChangesAsync();

            return widget;
        }

        return entity;
    }

    public async Task<bool> DeleteWidgetAsync(Guid employeeId)
    {
        var employee = await dbContext.Widgets.FirstOrDefaultAsync(x => x.Id == employeeId);

        if (employee is not null)
        {
            dbContext.Widgets.Remove(employee);

            return await dbContext.SaveChangesAsync() > 0;
        }

        return false;
    }
}