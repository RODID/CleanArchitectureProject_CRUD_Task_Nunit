using Application.Commands.Books;
using ClassLibrary;
using MediatR;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Application
{
    public class BookMethods
    {
        private static List<Book> _book = new List<Book>();

        internal readonly IMediator _mediator;

        public BookMethods(IMediator mediator)
        {
            _mediator = mediator;
        }


        public static Book AddNewBook(int id, string author, string bookName)
        {
            if (string.IsNullOrWhiteSpace(bookName) || string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("BookName and Author are required");

            if (_book.Exists(b => b.Id == id))
                throw new InvalidOperationException("A book with this ID already exists");

            var newBook = new Book(id, author, bookName)
            {
                Id = id,
                BookName = bookName,
                Author = author
            };

            _book.Add(newBook);

            return newBook;
        }
        public static Book GetBookById(int id)
        {
            return _book.SingleOrDefault(b => b.Id == id);
        }

        public static List<Book> GetAllBooks()
        {
            return new List<Book>(_book);
        }

        public static Book UpdateBook(int id, string newAuthor, string newBookName)
        {
            if (string.IsNullOrWhiteSpace(newAuthor) || string.IsNullOrWhiteSpace(newBookName))
                throw new ArgumentException("Author and BookName are required.");

            var bookToUpdate = _book.SingleOrDefault(b => b.Id == id);

            if (bookToUpdate == null)
                throw new InvalidOperationException("Book not found.");

            bookToUpdate.Author = newAuthor;
            bookToUpdate.BookName = newBookName;

            return bookToUpdate;
        }

        public static void DeleteBook(int id)
        {
            var bookToDelete = _book.SingleOrDefault(b => b.Id == id);

            if (bookToDelete == null)
            {
                throw new InvalidOperationException("Book not found");
            }

            _book.Remove(bookToDelete);
        }

    }
}
