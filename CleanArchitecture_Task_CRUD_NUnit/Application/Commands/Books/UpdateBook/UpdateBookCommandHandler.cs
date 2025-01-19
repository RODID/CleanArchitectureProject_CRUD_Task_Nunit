using Application.Interface.RepositoryInterface;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, OperationResult<Book>>
    {
        private readonly IGenericRepository<Book, Guid> _repository;

        public UpdateBookCommandHandler(IGenericRepository<Book, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bookToUpdate = await _repository.GetByIdAsync(request.BookId);
                if (bookToUpdate == null)
                {
                    return OperationResult<Book>.Failure(
                        $"Book with ID {request.BookId} wasn't found.",
                        "Update operation failed"
                    );
                }

                await _repository.UpdateAsync(bookToUpdate);

                return OperationResult<Book>.Success(
                    bookToUpdate,
                    "Book updated successfully"
                );
            }
            catch (Exception ex)
            {
                return OperationResult<Book>.Failure($"An error occurred: {ex.Message}");
            }
        }
    }
}
