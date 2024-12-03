namespace ClassLibrary
{
    public class Book
    {
        public Book(int id, string bookName, string author)
        {
            Id = id;
            Title = bookName;
            Description = author;
            
        }
        public Book()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
