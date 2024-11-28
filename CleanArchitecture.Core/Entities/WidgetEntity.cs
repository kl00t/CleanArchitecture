namespace CleanArchitecture.Core.Entities;

public class WidgetEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}