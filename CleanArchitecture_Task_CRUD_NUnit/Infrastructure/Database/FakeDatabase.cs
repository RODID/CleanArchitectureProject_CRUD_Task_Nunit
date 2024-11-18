using ClassLibrary;
namespace Infrastructure.Database
{
    public List <Book> Book { get { return allBooksFromDB; } set { allBooksFromDB = value; } }
    public class FakeDatabase
    {
        public static List<Book> allBooksFromDB = new List<Book>
        {
            new Book (1, "Rodi 1", "Book of Rodi 1"),
            new Book (2, "Rodi 2", "Book of Rodi 2"),
            new Book (3, "Rodi 3", "Book of Rodi 3"),
            new Book (4, "Rodi 4", "Book of Rodi 4"),
            new Book (5, "Rodi 5", "Book of Rodi 5"),

        };
    }
}
