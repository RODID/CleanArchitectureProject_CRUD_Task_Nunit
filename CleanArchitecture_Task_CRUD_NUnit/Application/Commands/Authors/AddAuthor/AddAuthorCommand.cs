using MediatR;
using Domain.CommandOperationResult;
using Application.Dtos;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommand : IRequest<OperationResult<GetAuthorDto>>
    {
        public AddAuthorDto NewAuthor { get; set; } 

        public AddAuthorCommand(AddAuthorDto newAuthor)
        {
            NewAuthor = newAuthor;
        }
    }
}
