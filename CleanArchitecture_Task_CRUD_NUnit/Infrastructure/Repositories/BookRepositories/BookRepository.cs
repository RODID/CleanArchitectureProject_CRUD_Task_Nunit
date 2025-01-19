//using Application.Interface.RepositoryInterface;
//using Domain;
//using Infrastructure.Database;
//using Microsoft.EntityFrameworkCore;

//namespace Infrastructure.Repositories.BookRepositories
//{
//    public class BookRepository : IBookRepository

//    {
//        private readonly RealDatabase _realDatabase;

//        public BookRepository(RealDatabase realDatabase)
//        {
//            _realDatabase = realDatabase;
//        }

//        public async Task<Book> AddBookAsync(Book book)
//        {
//            _realDatabase.Books.Add(book);
//            await _realDatabase.SaveChangesAsync();
//            return book;
//        }
//        public async Task<Book> UpdateBookAsync(Guid id, Book book)
//        {
//            var existingBook = await _realDatabase.Books.FindAsync(id);
//            if (existingBook == null) throw new KeyNotFoundException("Book not found");
            

//            existingBook.Title = book.Title;
//            existingBook.Description = book.Description;

//            _realDatabase.Books.Update(existingBook);
//            await _realDatabase.SaveChangesAsync();
//            return existingBook;
//        }

//        public async Task<string> DeleteBookByIdAsync(Guid id)
//        {
//            var book = await _realDatabase.Books.FindAsync(id);
//            if (book == null) throw new KeyNotFoundException("Book not found");

//            _realDatabase.Books.Remove(book);
//            await _realDatabase.SaveChangesAsync();
//            return $"Book with ID {id} deleted successfully.";

//        }

//        public async Task<List<Book>> GetAllBookAsync()
//        {
//            return await _realDatabase.Books.ToListAsync();
//        }

//        public async Task<Book> GetBookByIdAsync(Guid id)
//        {
//            return await _realDatabase.Books.FirstOrDefaultAsync(b => b.Id == id);
//        }
        
//    }
//}
