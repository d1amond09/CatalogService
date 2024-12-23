namespace CatalogService.Core.Domain.RequestFeatures;

public abstract class RequestParameters
{
    private const int MaxPageSize = 500;
    private int _pageSize = 10;

    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? 
            MaxPageSize : value;
    }
    
    public string OrderBy { get; set; } = string.Empty;
    public string Fields { get; set; } = string.Empty;
}