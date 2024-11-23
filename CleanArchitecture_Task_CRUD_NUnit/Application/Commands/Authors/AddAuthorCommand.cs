using MediatR;
using Domain;

namespace Application.Commands.Authors
{
    public class AddAuthorCommand : IRequest<Author>
    {
        public Author NewAuthor { get; }

        public AddAuthorCommand(Author author)
        {
            NewAuthor = author;
        }
    }
}
