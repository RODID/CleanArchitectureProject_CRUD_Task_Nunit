using MediatR;
using Domain;
using Domain.CommandOperationResult;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<OperationResult<bool>>
    {
        public Guid AuthorId { get; set; }

        public DeleteAuthorCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}
