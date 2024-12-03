using MediatR;
using Domain;
using Domain.CommandOperationResult;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommand : IRequest<OperationResult<List<Author>>>
    {
        public Author NewAuthor { get; }

        public AddAuthorCommand(Author authorToAdd)
        {
            NewAuthor = authorToAdd;
        }
    }
}
