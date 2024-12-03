using Domain;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<Author>
    {
        public int AuthorId { get; }
        public string NewName { get; }

        public UpdateAuthorCommand(int authorId, string authorName)
        {
            AuthorId = authorId;
            NewName = authorName;
        }
    }
}
