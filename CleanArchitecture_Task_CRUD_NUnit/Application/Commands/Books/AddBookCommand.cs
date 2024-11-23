using ClassLibrary;
using MediatR;

namespace Application.Commands.Books
{
    public class AddBookCommand : IRequest<List<Book>>
    {

        public AddBookCommand(Book bookToAdd) 
        {
            NewBook = bookToAdd;
        }
        public Book NewBook { get; }

    }
}
