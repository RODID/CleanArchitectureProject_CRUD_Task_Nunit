namespace ClassLibrary
{
    public class Book
    {
        public Book(int id, string bookName, string author)
        {
            Id = id;
            BookName = bookName;
            Author = author;
            
        }

        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }

    }
}
