using Domain;

namespace Application.Interface.RepositoryInterface
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Guid id, Author author);
        Task<string> DeleteAuthorAsync(Guid id);   
        Task <List<Author>> GetAllAuthorAsync();
        Task<Author> GetAuthorByIdAsync(Guid id);
    }
}
