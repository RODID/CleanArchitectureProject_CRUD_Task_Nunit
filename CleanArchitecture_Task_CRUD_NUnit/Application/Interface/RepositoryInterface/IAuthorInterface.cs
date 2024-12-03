using Domain;

namespace Application.Interface.RepositoryInterface
{
    public interface IAuthorInterface
    {
        Task<Author> AddAuthor(Author author);
    }
}
