using Application.Interfaces;
using ClassLibrary;
using MediatR;

namespace Application.Commands.Books
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository<Book> _repository;

        public DeleteBookCommandHandler(IBookRepository<Book> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = _repository.Delete(request.BookId);
            return Task.FromResult(result);
        }
    }
}
