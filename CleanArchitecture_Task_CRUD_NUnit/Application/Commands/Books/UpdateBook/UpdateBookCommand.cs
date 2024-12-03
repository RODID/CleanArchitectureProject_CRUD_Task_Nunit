using ClassLibrary;
using MediatR;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public int BookId { get; }
        public string NewTitle { get; }
        public string NewDescription { get; }

        public UpdateBookCommand(int bookId, string newTitle, string newDescription)
        {
            BookId = bookId;
            NewTitle = newTitle;
            NewDescription = newDescription;
        }

    }
}
