using CatalogService.Core.Domain.Entities;
using Grpc.Core;

namespace CatalogService.Services;

public class CatalogService : Catalog.CatalogBase
{
    private static readonly List<Book> Books = 
    [
        new Book()
        {
            Id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
            Title = "C# in Depth",
            Stock = 10,
            Description = null
        }
    ];

    public override Task<UpdateBookStockResponse> UpdateBookStock(UpdateBookStockRequest request, ServerCallContext context)
    {
        return Task.FromResult(new UpdateBookStockResponse { Success = false });
    }

    public override Task<GetBookResponse> GetBook(GetBookRequest request, ServerCallContext context)
    {
        var book = Books.FirstOrDefault(x => new Guid(request.BookId) == x.Id);
        if (book != null)
        {
            return Task.FromResult(new GetBookResponse
            {
                BookId = request.BookId,
                Title = book.Title,
                Stock = book.Stock,
            });
        }
        throw new RpcException(new Status(StatusCode.NotFound, $"Book not found {request.BookId} != {book?.Id} != {Books.First().Id}"));
    }
}