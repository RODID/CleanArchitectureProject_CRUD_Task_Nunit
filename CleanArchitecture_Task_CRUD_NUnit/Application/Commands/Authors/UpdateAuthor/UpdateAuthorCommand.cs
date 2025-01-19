using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<OperationResult<Author>>
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }
}
