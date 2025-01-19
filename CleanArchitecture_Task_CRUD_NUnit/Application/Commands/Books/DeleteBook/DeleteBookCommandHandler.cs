using MediatR;
using Domain.CommandOperationResult;
using Application.Interface.RepositoryInterface;
using Domain;

namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Book, Guid> _repository;
        public DeleteBookCommandHandler(IGenericRepository<Book, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isDeleted = await _repository.DeleteAsync(request.BookId);
                if (!isDeleted)
                {
                    return OperationResult<bool>.Failure("Book not found or could not be deleted.");
                }

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure($"An error occurred: {ex.Message}");
            }
        }
    }
}
