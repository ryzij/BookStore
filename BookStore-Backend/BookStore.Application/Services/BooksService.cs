using BookStore.Core.Abstractions;
using BookStore.Core.Models;

namespace BookStore.Application.Services;

public class BooksService(IBooksRepository repository) : IBooksService
{
    private readonly IBooksRepository _booksRepo = repository;

    public async Task<List<Book>> GetAllBooks()
    {
        return await _booksRepo.Get();
    }

    public async Task<Guid> CreateBook(Book book)
    {
        return await _booksRepo.Create(book);
    }

    public async Task<Guid> UpdateBook(Guid id, string? title, string? author, string? description, decimal price)
    {
        return await _booksRepo.Update(id, title, author, description, price);
    }

    public async Task<Guid> DeleteBook(Guid id)
    {
        return await _booksRepo.Delete(id);
    }
}