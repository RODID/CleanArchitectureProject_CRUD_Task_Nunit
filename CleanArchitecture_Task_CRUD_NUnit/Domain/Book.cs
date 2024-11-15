namespace ClassLibrary
{
    public class Book
    {
        public Book(int id, string author, string bookName)
        {
            Id = id;
            Author = author;
            BookName = bookName;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }

    }
}
