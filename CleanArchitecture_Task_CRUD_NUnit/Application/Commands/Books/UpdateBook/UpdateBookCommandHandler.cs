using Application.Dtos;
using Application.Interface.RepositoryInterface;
using AutoMapper;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, OperationResult<UpdateBookDto>>
    {
        private readonly IGenericRepository<Book, Guid> _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IGenericRepository<Book, Guid> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<UpdateBookDto>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBook = await _repository.GetByIdAsync(request.Dto.Id);
                if (existingBook == null)
                {
                    return OperationResult<UpdateBookDto>.Failure("Book not found.");
                }

                existingBook.Title = request.Dto.Title;
                existingBook.Description = request.Dto.Description;

                var updatedBook = await _repository.UpdateAsync(existingBook);

                if (updatedBook == null)
                {
                    return OperationResult<UpdateBookDto>.Failure("Failed to update book.");
                }

                var updatedDto = _mapper.Map<UpdateBookDto>(updatedBook);
                return OperationResult<UpdateBookDto>.Success(updatedDto);
            }
            catch (Exception ex)
            {
                return OperationResult<UpdateBookDto>.Failure($"An error occurred: {ex.Message}");
            }
        }
    }
}
