using MediatR;
using Domain;
using Domain.CommandOperationResult;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommand : IRequest<OperationResult<bool>>
    {
        public string Name { get; }

        public AddAuthorCommand(string authorToAdd)
        {
            Name = authorToAdd;
        }
    }
}
