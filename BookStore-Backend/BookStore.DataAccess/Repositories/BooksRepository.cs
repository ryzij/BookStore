using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using BookStore.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories;

public class BooksRepository(BookStoreDbContext db) : IBooksRepository
{
    private readonly BookStoreDbContext _db = db;

    public async Task<List<Book>> Get()
    {
        var bookEntities = await _db.Books.AsNoTracking().ToListAsync();

        var books = bookEntities.Select(b =>
            Book.Create(b.Id, b.Title, b.Author, b.Description, b.Price).Book)
            .ToList();

        return books;
    }

    public async Task<Guid> Create(Book book)
    {
        var bookEntity = new BookEntity
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            Price = book.Price
        };

        await _db.Books.AddAsync(bookEntity);
        await _db.SaveChangesAsync();

        return bookEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string? title, string? author, string? description, decimal price)
    {
        await _db.Books.Where(b => b.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, b => title ?? b.Title)
                .SetProperty(b => b.Author, b => author ?? b.Author)
                .SetProperty(b => b.Description, b => description ?? b.Description)
                .SetProperty(b => b.Price, b => price < 0 ? b.Price : price));

        return id;
    }
    
    public async Task<Guid> Delete(Guid id)
    {
        await _db.Books.Where(b => b.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}