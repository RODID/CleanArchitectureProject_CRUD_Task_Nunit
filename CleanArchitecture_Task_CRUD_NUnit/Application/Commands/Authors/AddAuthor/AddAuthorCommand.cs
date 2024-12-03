using MediatR;
using Domain;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommand : IRequest<List<Author>>
    {
        public Author NewAuthor { get; }

        public AddAuthorCommand(Author authorToAdd)
        {
            NewAuthor = authorToAdd;
        }
    }
}
