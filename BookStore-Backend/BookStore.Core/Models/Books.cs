namespace BookStore.Core.Models;

public class Book
{
    public const int MAX_TITLE_LENGTH = 250;
    public const int MAX_AUTHOR_NAME_LENGTH = 250;
    public const int MAX_DESCRIPTION_LENGTH = 5000;
    
    private Book(Guid id, string title, string author, string description, decimal price)
    {
        Id = id;
        Title = title;
        Author = author;
        Description = description;
        Price = price;
    }

    public Guid Id { get; }
    public string Title { get; } = string.Empty;
    public string Author { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public decimal Price { get; }

    public static (Book Book, List<string> Errors) Create(Guid id, string title, string author, string description, decimal price)
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            errors.Add("Uncorrect title");
        if (string.IsNullOrEmpty(author) || author.Length > MAX_AUTHOR_NAME_LENGTH)
            errors.Add("Uncorrect author name");
        if (description.Length > MAX_DESCRIPTION_LENGTH)
            errors.Add("The description length must be less than 5000 characters");

        return (new Book(id, title, author, description, price), errors);
    }
}