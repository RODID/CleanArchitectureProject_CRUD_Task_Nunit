using Domain;
using MediatR;

namespace Application.Commands.Authors
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly List<Author> _authors;

        public UpdateAuthorCommandHandler (List<Author> authors)
        {
            _authors = authors;
        }

        public Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _authors.FirstOrDefault(a => a.AuthorName == request.UpdatedAuthor.AuthorName);

            if (author != null)
            {
                author.AuthorAge = request.UpdatedAuthor.AuthorAge;
                return Task.FromResult(true);
            }
            return Task.FromResult (false);
        }
    }
}
