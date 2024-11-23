using Domain;
using MediatR;

namespace Application.Queries.Auhtors
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly List<Author> _authors;

        public GetAuthorByIdQueryHandler(List<Author> authors)
        {
            _authors = authors;
        }

        public Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = _authors.FirstOrDefault(a => a.AuthorName == request.AuthorName);
            return Task.FromResult(author);
        }
    }
}
