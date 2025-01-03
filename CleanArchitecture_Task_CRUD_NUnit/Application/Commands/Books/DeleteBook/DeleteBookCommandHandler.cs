using MediatR;
using Domain.CommandOperationResult;
using Application.Interface.RepositoryInterface;

namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand,OperationResult<bool>>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public async Task<OperationResult<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bookToRemove = await _bookRepository.GetBookByIdAsync(request.BookId);
                if (bookToRemove == null)
                {
                    return OperationResult<bool>.Failure("Book not found", "Failed to delete book");
                }


                var allBooks = await _bookRepository.DeleteBookByIdAsync(bookToRemove.Id);

                return OperationResult<bool>.Success(true, "Book successfully deleted!");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure(ex.Message, "An error occured when removing book!");
            }

        }
    }
}
