using Application.Interface.RepositoryInterface;
using ClassLibrary;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<OperationResult<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bookToUpdate = await _bookRepository.GetBookByIdAsync(request.BookId);
                if (bookToUpdate == null)
                {
                    return OperationResult<Book>.Failure(
                        $"Book with ID {request.BookId} wasn't found.",
                        "Update operation failed"
                    );
                }

                bookToUpdate.Title = request.NewTitle;
                bookToUpdate.Description = request.NewDescription;

                await _bookRepository.UpdateBookAsync(bookToUpdate.Id, bookToUpdate);

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
