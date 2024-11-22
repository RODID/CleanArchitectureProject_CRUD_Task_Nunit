using MediatR;

namespace Application.Commands.Books
{
    public class AddBookCommand : IRequest<int>
    {
        public string  Author { get; set; }
        public string BookName { get; set; }

        public AddBookCommand ( string author, string bookName)
        {
            Author = author;
            BookName = bookName;
        }

    }
}
