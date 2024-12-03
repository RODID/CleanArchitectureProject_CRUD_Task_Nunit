using ClassLibrary;
using Domain;
using System.Threading;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> AllBooksFromDB { get; set; }
        public List<Author> AllAuthorsFromDB { get; set; }

        public List<User> AllUsersFromDB { get; set; }

        public FakeDatabase()
        {
            AllBooksFromDB = new List<Book>
            {
                new Book(1, "Rodi 1", "Journey"),
                new Book(2, "Rodi 2", "Fighting"),
                new Book(3, "Rodi 3", "Crime"),
            };

            AllAuthorsFromDB = new List<Author>
            {
                new Author(1, "Arjan1"),
                new Author(2, "Arjan2"),
                new Author(3, "Arjan3"),

            };

            AllUsersFromDB = new List<User>
            {
                new User(Guid.NewGuid(), "UserOne", "Arjan!123"),
                new User(Guid.NewGuid(), "UserTwo", "Arjan!123"),
                new User(Guid.NewGuid(), "UserThree", "Arjan!123")
            };
        }
        
    }
}
