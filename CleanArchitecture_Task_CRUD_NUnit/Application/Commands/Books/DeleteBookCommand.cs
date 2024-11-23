using MediatR;


namespace Application.Commands.Books
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
