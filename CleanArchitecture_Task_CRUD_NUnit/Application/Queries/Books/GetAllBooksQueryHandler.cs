using ClassLibrary;
using MediatR;
using Application.Interfaces;

namespace Application.Queries.Books
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IBookRepository<Book> _repository;

        public GetAllBooksQueryHandler(IBookRepository<Book> repository) 
        {
            _repository = repository;
        }

        public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _repository.GetAll();
            return Task.FromResult(books);
        }
    }
}
