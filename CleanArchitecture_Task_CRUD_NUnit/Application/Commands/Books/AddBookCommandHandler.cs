using MediatR;
using ClassLibrary;
using Infrastructure.Database;

namespace Application.Commands.Books
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
            _fakeDatabase.AllBooksFromDb.Add(request.NewBook);
            return Task.FromResult(_fakeDatabase.AllBooksFromDb);
        }
    }
}
