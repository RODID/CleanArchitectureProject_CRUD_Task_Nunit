using ClassLibrary;
using MediatR;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public Guid BookId { get; }
        public string NewTitle { get; }
        public string NewDescription { get; }

        public UpdateBookCommand(Guid bookId, string newTitle, string newDescription)
        {
            BookId = Guid.NewGuid();
            NewTitle = newTitle;
            NewDescription = newDescription;
        }

    }
}
