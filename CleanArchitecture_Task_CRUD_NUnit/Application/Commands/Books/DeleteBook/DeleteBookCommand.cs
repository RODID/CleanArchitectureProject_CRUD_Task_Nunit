using MediatR;
using ClassLibrary;


namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommand : IRequest<bool>
    {

        public int BookId { get; }

        public DeleteBookCommand(int bookId)
        {
            BookId = bookId;
        }
    }
}
