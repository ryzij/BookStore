using BookStore.API.Contracts;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(IBooksService booksService) : ControllerBase
{
    private readonly IBooksService _booksService = booksService;

    [HttpGet]
    public async Task<ActionResult<List<BooksResponse>>> Get()
    {
        var books = await _booksService.GetAllBooks();

        var response = books.Select(b => new BooksResponse
        {
           Id = b.Id,
           Title = b.Title,
           Author = b.Author,
           Description = b.Description,
           Price = b.Price 
        });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request)
    {
        var (book, errors) = Book.Create(Guid.NewGuid(), request.Title, request.Author, request.Description, request.Price);
        if (errors.Count > 0)
            return BadRequest(errors);

        await _booksService.CreateBook(book);

        return CreatedAtAction(nameof(Create), book);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Guid>> Update(Guid id, UpdateBookRequest request)
    {
        var bookId = await _booksService.UpdateBook(id, request.Title, request.Author, request.Description, request.Price);
        return Ok(bookId);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Guid>> Delete(Guid id)
    {
        var bookId = await _booksService.DeleteBook(id);
        return Ok(bookId);
    }
}