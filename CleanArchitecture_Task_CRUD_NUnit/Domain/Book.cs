using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Book
{
    public Book(Guid id, string bookName, int yearPublished, string description)
    {
        Id = id;
        Title = bookName;
        YearPublished = yearPublished;
        Description = description;
        
    }
    public Book()
    {

    }

    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
    public string Title { get; set; }

    [Range(1450, int.MaxValue, ErrorMessage = "Year Published must be valid.")]
    public int YearPublished { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
    public string Description { get; set; }

    }
}
