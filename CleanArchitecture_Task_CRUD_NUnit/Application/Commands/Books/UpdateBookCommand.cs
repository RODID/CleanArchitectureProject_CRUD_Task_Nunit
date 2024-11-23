using ClassLibrary;
using MediatR;

namespace Application.Commands.Books
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public Book UpdateBook { get; }

        public UpdateBookCommand(Book updateBook)
        {
            UpdateBook = updateBook;
        }

    }
}
