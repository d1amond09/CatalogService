using CatalogService.Core.Application.Contracts;
using CatalogService.Core.Domain.RequestFeatures;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CatalogService.Services;

public class CatalogService(IBookRepository bookRep) : Catalog.CatalogBase
{
    private readonly IBookRepository _bookRep = bookRep;  

    public override async Task<GetBookResponse> GetBook(GetBookRequest request, ServerCallContext context)
    {
        var book = await _bookRep.GetBookAsync(new Guid(request.BookId), false);
        if (book != null)
        {
            return new GetBookResponse
            {
                BookId = request.BookId,
                Title = book.Title,
                Stock = book.Stock,
                Description = book.Description
            };
        }
        throw new RpcException(new Status(StatusCode.NotFound, $"Book not found {request.BookId}"));
    }
    
    public override async Task<GetBooksResponse> GetBooks(Empty request, ServerCallContext context)
    {
        BookParameters bookParameters = new();
        var books = await _bookRep.GetAllBooksAsync(bookParameters, false);
        
        var grpcBooks = books.Select(book => new GrpcBook
        {
            BookId = book.Id.ToString(), 
            Title = book.Title,
            Stock = book.Stock,
            Description = book.Description,
        }).ToList();

        return new GetBooksResponse
        {
            Books = { grpcBooks } 
        };
    }
}