using MediatR;
using ClassLibrary;
using Infrastructure.Database;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, List<Book>>
    {
        private readonly FakeDatabase _fakeDatabase;
        public AddBookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<Book>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            if (_fakeDatabase.AllBooksFromDB.Any(book => book.Id == request.NewBook.Id))
            {
                throw new InvalidOperationException("A book With the same ID already exists!");
            }
            _fakeDatabase.AllBooksFromDB.Add(request.NewBook);
            return Task.FromResult(_fakeDatabase.AllBooksFromDB);
        }
    }
}
