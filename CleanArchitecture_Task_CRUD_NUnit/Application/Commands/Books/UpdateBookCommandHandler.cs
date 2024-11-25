using ClassLibrary;
using MediatR;

namespace Application.Commands.Books
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly List<Book> _books;

        public UpdateBookCommandHandler(List<Book> books)
        {
            _books = books;
        }

        public Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = _books.SingleOrDefault(b => b.Id == request.BookId);
            if (bookToUpdate == null)
            {
                return Task.FromResult(false);
            }

            bookToUpdate.Author = request.UpdateBook.Author;
            bookToUpdate.BookName = request.UpdateBook.BookName;

            return Task.FromResult(true);
        }
    }
}
