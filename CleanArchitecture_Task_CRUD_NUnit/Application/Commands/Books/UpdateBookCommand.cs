using ClassLibrary;
using MediatR;

namespace Application.Commands.Books
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public int BookId { get; }
        public Book UpdateBook { get; }

        public UpdateBookCommand(int bookId,  Book updateBook)
        {
            BookId = bookId;
            UpdateBook = updateBook;
        }

    }
}
