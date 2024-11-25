using ClassLibrary;
using Domain;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> AllBooksFromDb { get; set; }
        public List<Author> AllAuthorsFromDB { get; set; }

        public FakeDatabase()
        {
            AllBooksFromDb = new List<Book>
            {
                new Book(1, "Rodi 1", "Book of Rodi 1"),
                new Book(2, "Rodi 2", "Book of Rodi 2"),
                new Book(3, "Rodi 3", "Book of Rodi 3"),
                new Book(4, "Rodi 4", "Book of Rodi 4")
            };

            AllAuthorsFromDB = new List<Author>
            {
                new Author("Arjan 1", 20),
                new Author("Arjan 1", 20),
                new Author("Arjan 1", 20),
                new Author("Arjan 1", 20),
            };
        }
        
    }
}
