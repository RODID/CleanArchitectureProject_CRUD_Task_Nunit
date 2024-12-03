namespace ClassLibrary;

public class Book
{
    public Book(Guid id, string bookName, string author)
    {
        Id = id;
        Title = bookName;
        Description = author;
        
    }
    public Book()
    {

    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

}
