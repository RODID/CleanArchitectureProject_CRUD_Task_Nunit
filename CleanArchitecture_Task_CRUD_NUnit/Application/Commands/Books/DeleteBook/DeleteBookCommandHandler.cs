using ClassLibrary;
using MediatR;
using Infrastructure.Database;
using Domain.CommandOperationResult;

namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand,OperationResult<bool>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public DeleteBookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<OperationResult<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bookToRemove = _fakeDatabase.AllBooksFromDB.FirstOrDefault(a => a.Id == request.BookId);
                if (bookToRemove == null)
                {
                    return Task.FromResult(OperationResult<bool>.Failure("Book not found."));
                }

                _fakeDatabase.AllBooksFromDB.Remove(bookToRemove);

                return Task.FromResult(OperationResult<bool>.Success(true, "Book deleted successfully."));

            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<bool>.Failure($"An error occurred: {ex.Message}"));
            }


        }

    }
}
