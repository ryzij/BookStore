using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookStore.Core.Models;
using BookStore.DataAccess.Entities;

namespace BookStore.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.Title)
            .HasMaxLength(Book.MAX_TITLE_LENGTH)
            .IsRequired();

        builder.Property(b => b.Author)
            .HasMaxLength(Book.MAX_AUTHOR_NAME_LENGTH)
            .IsRequired();

        builder.Property(b => b.Description)
            .HasMaxLength(Book.MAX_DESCRIPTION_LENGTH);

        builder.Property(b => b.Price)
            .IsRequired();
    }
}