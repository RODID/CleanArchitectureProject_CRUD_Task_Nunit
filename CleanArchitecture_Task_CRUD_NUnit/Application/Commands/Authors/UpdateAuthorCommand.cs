using Domain;
using MediatR;

namespace Application.Commands.Authors
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public Author UpdatedAuthor { get; }

        public UpdateAuthorCommand(Author updatedAuthor)
        {
            UpdatedAuthor = updatedAuthor;
        }
    }
}
