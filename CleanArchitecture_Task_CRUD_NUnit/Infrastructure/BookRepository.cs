using ClassLibrary;

namespace Infrastructure
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly List<Book> _books = new();

        public Book GetById(int id)
        {
            return _books.SingleOrDefault(b => b.Id == id);
        }

        public List<Book> GetAll()
        {
            return new List<Book>(_books);
        }

        public void Add(Book book)
        {
            if (_books.Exists(b => b.Id == book.Id))
                throw new Exception("A book with this id already exists.");

            _books.Add(book);
        }

        public bool Update(Book book)
        {
            var existingBook = GetById(book.Id);
            if (existingBook == null)
                return false;

            existingBook.Author = book.Author;
            existingBook.BookName = book.BookName;
            return true;
        }

        public bool Delete(int id)
        {
            var bookToDelete = GetById(id);
            if (bookToDelete == null)
                return false;

            _books.Remove(bookToDelete);
            return true;
        }
    }
}
