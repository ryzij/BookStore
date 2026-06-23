using System.ComponentModel.DataAnnotations;
using BookStore.Core.Models;

namespace BookStore.API.Contracts;

public class CreateBookRequest
{
    [Required, Length(1, Book.MAX_TITLE_LENGTH)]
    public string Title { get; set; } = string.Empty;

    [Required, Length(1, Book.MAX_AUTHOR_NAME_LENGTH)]
    public string Author { get; set; } = string.Empty;
    
    [Length(0, Book.MAX_DESCRIPTION_LENGTH)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }
}