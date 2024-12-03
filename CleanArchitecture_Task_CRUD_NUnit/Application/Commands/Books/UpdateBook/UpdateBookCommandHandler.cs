using ClassLibrary;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly FakeDatabase _fakeDatabase;

        public UpdateBookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = _fakeDatabase.AllBooksFromDB.FirstOrDefault(a => a.Id == request.BookId);
            if (bookToUpdate == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.BookId} wasn't found.");
            }

            bookToUpdate.Title = request.NewTitle;
            bookToUpdate.Description = request.NewDescription;

            return Task.FromResult(bookToUpdate);
        }
    }
}
