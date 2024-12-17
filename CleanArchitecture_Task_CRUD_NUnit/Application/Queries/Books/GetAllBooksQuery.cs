using ClassLibrary;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Books
{
    public class GetAllBooksQuery : IRequest<OperationResult<List<Book>>>
    {
        
    }
}
