using Domain;

namespace Application.Commands.Authors
{
    public class DeleteAuthorCommandHandler
    {
        private readonly List<Author> _authors;

        public DeleteAuthorCommandHandler(List<Author> authors)
        {
            _authors = authors;
        }

        public Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _authors.FirstOrDefault(a => a.AuthorName == request.AuthorName);
            if (author != null)
            {
                _authors.Remove(author);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
