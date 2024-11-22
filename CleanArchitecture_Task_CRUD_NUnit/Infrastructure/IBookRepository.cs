using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IBookRepository
    {
        Book GetById(int id);

        List<Book> GetAll();
        void Add(Book book);
        bool Update(Book book);
        bool Delete(int id);

    }
}
