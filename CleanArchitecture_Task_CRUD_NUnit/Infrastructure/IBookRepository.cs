using ClassLibrary;

namespace Infrastructure
{
    public interface IBookRepository<T>
    {
        Book GetById(int bookId);

        public interface IBookRepository<Book> where Book : class
        {
            Book GetById(int id);
            List<Book> GetAll();
            void Add(Book book);
            bool Update(Book book);
            bool Delete(int id);

        }
    }

}
