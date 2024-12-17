using System.Collections.Generic;

namespace ClassLibrary;

public class Book
{
    public Book(Guid id, string bookName, string description)
    {
        Id = id;
        Title = bookName;
        Description = description;
        
    }
    public Book()
    {

    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();

}
