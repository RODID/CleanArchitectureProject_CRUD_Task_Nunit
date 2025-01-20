using MediatR;
using Domain;
using Domain.CommandOperationResult;


namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommand : IRequest<OperationResult<bool>>
    {
        public Guid BookId { get; set; }
        public DeleteBookCommand(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
