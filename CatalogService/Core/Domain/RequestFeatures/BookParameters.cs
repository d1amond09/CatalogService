namespace CatalogService.Core.Domain.RequestFeatures;

public class BookParameters : RequestParameters
{
    public string SearchTerm { get; set; } = string.Empty;
    
    public BookParameters()
    {
        OrderBy = "title";
    }
}