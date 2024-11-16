using ClassLibrary;

namespace BookRepository
{
    public interface IBookRepository
    {
        Book GetById(int id);
        bool Update(Book book);
    }
}
