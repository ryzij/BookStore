using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BookStore.Core.Models;
namespace BookStore.API.Contracts;

public class UpdateBookRequest
{
    [Length(0, Book.MAX_TITLE_LENGTH)]
    public string? Title { get; set; }

    [Length(1, Book.MAX_AUTHOR_NAME_LENGTH)]
    public string Author { get; set; } = string.Empty;
    
    [Length(0, Book.MAX_DESCRIPTION_LENGTH)]
    public string? Description { get; set; }

    [DefaultValue(-1)]
    public decimal Price { get; set; } = -1;
}