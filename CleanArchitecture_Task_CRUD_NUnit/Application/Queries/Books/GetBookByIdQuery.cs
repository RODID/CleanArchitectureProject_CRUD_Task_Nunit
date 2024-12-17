using ClassLibrary;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Books
{
    public class GetBookByIdQuery : IRequest<OperationResult<List<Book>>>
    {
        public Guid BookId { get; set; }

        public GetBookByIdQuery(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
