using MediatR;
using Domain;
using Domain.CommandOperationResult;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<OperationResult<List<Author>>>
    {
        public Guid AuthorId { get; }

        public DeleteAuthorCommand(Guid authorId)
        {
            AuthorId = Guid.NewGuid();
        }


    }
}
