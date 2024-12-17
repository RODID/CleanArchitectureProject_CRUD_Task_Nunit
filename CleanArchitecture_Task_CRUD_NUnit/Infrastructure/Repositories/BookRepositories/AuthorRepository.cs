using Application.Interface.RepositoryInterface;
using Domain;
using Infrastructure.Database;

namespace Infrastructure.Repositories.BookRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RealDatabase _realdatabase;

        public AuthorRepository(RealDatabase realdatabase)
        {
            _realdatabase = realdatabase;
        }

        public Task<Author> AddAuthorAsync(Author author)
        {
            _realdatabase.Authors.Add(author);
            _realdatabase.SaveChanges();

            return Task.FromResult(author);
        }

        public Task<string> DeleteAuthorAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAllAuthorAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthorAsync(Guid id, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
