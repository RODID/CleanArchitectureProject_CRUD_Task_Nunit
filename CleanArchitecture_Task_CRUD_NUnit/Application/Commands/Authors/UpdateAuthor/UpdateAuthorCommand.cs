using Application.Dtos;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<OperationResult<UpdateAuthorDto>>
    {
        public UpdateAuthorDto Dto { get; set; }

        public UpdateAuthorCommand(UpdateAuthorDto dto)
        {
            Dto = dto;
        }
    }
}
