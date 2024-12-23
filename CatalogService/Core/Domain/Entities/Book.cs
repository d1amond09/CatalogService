namespace CatalogService.Core.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Stock { get; set; }
}