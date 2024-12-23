using CatalogService.Core.Application.Contracts;
using CatalogService.Core.Domain.Entities;
using CatalogService.Core.Domain.RequestFeatures;
using CatalogService.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class BookRepository(CatalogDbContext dbContext) : RepositoryBase<Book>(dbContext), IBookRepository
{
    public void CreateBook(Book book) => Create(book);
    public void UpdateBook(Book book) => Update(book);
    public void DeleteBook(Book book) => Delete(book);

    public async Task<IEnumerable<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges = false)
    {
        var books = FindAll(trackChanges)
            .Search(bookParameters.SearchTerm)
            .Sort(bookParameters.OrderBy);

        var count = await books.CountAsync();

        var booksToReturn = await books
            .Skip((bookParameters.PageNumber - 1) * bookParameters.PageSize)
            .Take(bookParameters.PageSize)
            .ToListAsync();

        return booksToReturn;
    }
    
    public async Task<Book?> GetBookAsync(Guid bookId, bool trackChanges = false) =>
        await FindByCondition(c => c.Id.Equals(bookId), trackChanges)
            .SingleOrDefaultAsync();

    public async Task<IEnumerable<Book>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges = false) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToListAsync();
}