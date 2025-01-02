using CatalogService.Core.Application.Contracts;
using CatalogService.Infrastructure;
using CatalogService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddDataBase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<CatalogDbContext>(opts =>
            opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b =>
            {
                b.MigrationsAssembly("CatalogService");
                b.EnableRetryOnFailure();
            })
        );
        return builder;
    }
    
    public static WebApplicationBuilder AddGrpc(this WebApplicationBuilder builder)
    {
        builder.Services.AddGrpc();
        return builder;
    }
    
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        
        return builder;
    }
}