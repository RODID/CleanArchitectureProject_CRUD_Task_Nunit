using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<OperationResult<Author>>
    {
        public Guid AuthorId { get; }
        public string NewName { get; }

        public UpdateAuthorCommand(Guid authorId, string authorName)
        {
            AuthorId = authorId;
            NewName = authorName;
        }
    }
}
