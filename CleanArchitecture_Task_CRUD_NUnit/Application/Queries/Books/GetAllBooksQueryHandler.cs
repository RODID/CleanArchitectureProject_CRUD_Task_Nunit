using ClassLibrary;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Books
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly FakeDatabase _fakeDatabase;
        public GetAllBooksQueryHandler(FakeDatabase fakeDatabase) 
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_fakeDatabase.AllBooksFromDb);
          
        }
    }
}
