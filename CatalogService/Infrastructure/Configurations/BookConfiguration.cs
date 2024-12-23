using CatalogService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Configurations;

public class BookConfiguration: IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(e => e.Id)
            .IsRequired()
            .HasDefaultValueSql("NEWID()")
            .HasColumnName("CourseID");

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Description);

        builder.Property(e => e.Stock)
            .IsRequired();

        builder.HasData(
        [
            new Book
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Title = "Harry Potter and the Sorcerer’s Stone",
                Stock = 320,
                Description = null,
            }
        ]);
    }
}