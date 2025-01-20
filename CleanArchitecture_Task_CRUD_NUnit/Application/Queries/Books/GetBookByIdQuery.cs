using Application.Dtos;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Books
{
    public class GetBookByIdQuery : IRequest<OperationResult<GetAllBooksDto>>
    {
        public int BookId { get; set; }

        public GetBookByIdQuery(int bookId)
        {
            BookId = bookId;
        }
    }
}
