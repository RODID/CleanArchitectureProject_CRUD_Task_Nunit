using ClassLibrary;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommand : IRequest<OperationResult<Book>>
    {
        public AddBookCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; }
        public string Description { get; set; }


    }
}
