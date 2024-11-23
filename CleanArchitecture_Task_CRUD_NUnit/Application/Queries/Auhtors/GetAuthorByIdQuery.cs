using Domain;
using MediatR;

namespace Application.Queries.Auhtors
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public string AuthorName { get; }

        public GetAuthorByIdQuery(string authorName)
        {
            AuthorName = authorName;
        }
    }
}
