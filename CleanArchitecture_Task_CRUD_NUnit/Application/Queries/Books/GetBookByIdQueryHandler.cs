using ClassLibrary;
using Infrastructure;
using MediatR;


namespace Application.Queries.Books
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository<Book> _repository;

        public GetBookByIdQueryHandler(IBookRepository<Book> repository)
        {
            _repository = repository;
        }

        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = _repository.GetById(request.BookId);
            return Task.FromResult(book);
        }

    }
}
