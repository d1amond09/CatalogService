using CatalogService.Core.Domain.Entities;
using CatalogService.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }
}