using ClassLibrary;
using MediatR;

namespace Application.Queries.Books
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {
        
    }
}
