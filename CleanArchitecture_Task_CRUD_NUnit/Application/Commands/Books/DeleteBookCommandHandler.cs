using ClassLibrary;
using MediatR;
using Infrastructure.Database;

namespace Application.Commands.Books
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly List<Book> _books;

        public DeleteBookCommandHandler(List<Book> books)
        {
            _books = books;
        }

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var bookTodelete = _books.SingleOrDefault(b => b.Id == request.BookId);
            if (bookTodelete == null) 
            {
                return Task.FromResult(false);
            }
            _books.Remove(bookTodelete);
            return Task.FromResult(true);

        }
    }
}
