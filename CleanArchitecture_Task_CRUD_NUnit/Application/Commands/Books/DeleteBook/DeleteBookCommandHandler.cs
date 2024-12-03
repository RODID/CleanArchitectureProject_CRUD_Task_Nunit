using ClassLibrary;
using MediatR;
using Infrastructure.Database;

namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly FakeDatabase _fakeDatabase;

        public DeleteBookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var bookToRemove = _fakeDatabase.AllBooksFromDB.FirstOrDefault(a => a.Id == request.BookId);
            if (bookToRemove != null)
            {
                return Task.FromResult(false);
            }

            _fakeDatabase.AllBooksFromDB.Remove(bookToRemove);

            return Task.FromResult(true);

        }
    }
}
