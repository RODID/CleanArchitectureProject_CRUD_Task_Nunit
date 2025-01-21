using Application.Dtos;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommand : IRequest<OperationResult<UpdateBookDto>>
    {
        public UpdateBookDto Dto { get; set; }

        public UpdateBookCommand(UpdateBookDto dto)
        {
            Dto = dto;
        }
    }
}
