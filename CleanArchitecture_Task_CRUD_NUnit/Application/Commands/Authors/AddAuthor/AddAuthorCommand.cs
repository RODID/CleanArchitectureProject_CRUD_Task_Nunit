using MediatR;
using Domain.CommandOperationResult;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommand : IRequest<OperationResult<bool>>
    {
        public string AuthorName { get; }

        public AddAuthorCommand(string authorToAdd)
        {
            AuthorName = authorToAdd;
        }
    }
}
