using CatalogService.Core.Domain.Entities;
using CatalogService.Infrastructure.Extensions.Utility;
﻿using System.Linq.Dynamic.Core;

namespace CatalogService.Infrastructure.Extensions;

public static class RepositoryBookExtensions
{
    public static IQueryable<Book> Search(this IQueryable<Book> books, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return books;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return books.Where(e => e.Title!.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<Book> Sort(this IQueryable<Book> books, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return books.OrderBy(e => e.Title);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Book>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return books.OrderBy(e => e.Title);

        return books.OrderBy(orderQuery);
    }
}