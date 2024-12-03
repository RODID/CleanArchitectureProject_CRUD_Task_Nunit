using ClassLibrary;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Books
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, List<Book>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public GetBookByIdQueryHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<Book>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_fakeDatabase.AllBooksFromDB);
        }
    }
}
