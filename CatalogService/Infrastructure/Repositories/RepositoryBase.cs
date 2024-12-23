using System.Linq.Expressions;
using CatalogService.Core.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public abstract class RepositoryBase<T>(CatalogDbContext dbContext) : IRepositoryBase<T> where T : class
{
    protected readonly CatalogDbContext _dbContext = dbContext;

    public IQueryable<T> FindAll(bool trackChanges = false) =>
        !trackChanges ? _dbContext.Set<T>()
            .AsNoTracking() : _dbContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
        !trackChanges ? _dbContext.Set<T>().Where(expression)
            .AsNoTracking() : _dbContext.Set<T>().Where(expression);
    
    public void Create(T entity) => _dbContext.Set<T>().Add(entity);
    public void Update(T entity) => _dbContext.Set<T>().Update(entity);
    public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);
}