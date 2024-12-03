using MediatR;
using Domain;
using Domain.CommandOperationResult;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<OperationResult<List<Author>>>
    {
        public int AuthorId { get; }

        public DeleteAuthorCommand(int authorId)
        {
            AuthorId = authorId;
        }


    }
}
