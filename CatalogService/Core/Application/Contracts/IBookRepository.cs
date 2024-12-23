using System.Linq.Expressions;
using CatalogService.Core.Domain.Entities;
using CatalogService.Core.Domain.RequestFeatures;

namespace CatalogService.Core.Application.Contracts;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges = false);
    Task<IEnumerable<Book>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges = false);
    Task<Book?> GetBookAsync(Guid bookId, bool trackChanges);
    public void CreateBook(Book book);
    public void DeleteBook(Book book);
    public void UpdateBook(Book book);
    
    IQueryable<Book> FindByCondition(Expression<Func<Book, bool>> expression, bool trackChanges = false);
}