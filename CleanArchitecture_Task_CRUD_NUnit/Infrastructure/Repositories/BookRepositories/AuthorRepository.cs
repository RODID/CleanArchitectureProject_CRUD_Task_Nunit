//using Application.Interface.RepositoryInterface;
//using Domain;
//using Infrastructure.Database;
//using Microsoft.Extensions.Logging;

//namespace Infrastructure.Repositories.BookRepositories
//{
//    public class AuthorRepository : IAuthorRepository
//    {
//        private readonly RealDatabase _realDatabase;
//        private readonly ILogger<AuthorRepository> _logger;

//        public AuthorRepository(RealDatabase realdatabase, ILogger<AuthorRepository> logger)
//        {
//            _realDatabase = realdatabase;
//            _logger = logger;
//        }

//        public async Task<Author> AddAuthorAsync(Author author)
//        {
//            _logger.LogInformation("Adding author:{AuthorName}", author.Name);

//            _realDatabase.Authors.Add(author);
//            _realDatabase.SaveChanges();

//            _logger.LogInformation("Author: {author.Name} added successfully ", author.Name);
//            return author;

            
//        }

//        public Task<string> DeleteAuthorAsync(Guid id)
//        {
//            var authorToDelete = _realDatabase.Authors.Where(author => author.Id == id).First();
//            if (authorToDelete is not null)
//            {
//                _realDatabase.Authors.Remove(authorToDelete);
//                _realDatabase.SaveChanges();
//                _logger.LogInformation("Author with ID {AuthorId} deleted.", id);
//                return Task.FromResult("Succes");
//            }
//            else
//            {
//                _logger.LogWarning("Attempted to delete author with ID {AuthorId}, but not found.", id);
//                return Task.FromResult("Fail");
//            }
//        }

//        public async Task<List<Author>> GetAllAuthorAsync()
//        {
//            _logger.LogInformation("Fetching all authors from the database.");
//            var authors = await Task.FromResult(_realDatabase.Authors.ToList());
//            _logger.LogInformation("Fetched {Count} authors from the database.", authors.Count);
//            return authors;
//        }

//        public async Task<List<Author>> GetAuthorByIdAsync(Guid id)
//        {
//            _logger.LogInformation("Fetching author with ID {AuthorId}", id);
//            var author = await Task.FromResult(_realDatabase.Authors.Where(author => author.Id == id).ToList());
//            if (author.Count == 0)
//            {
//                _logger.LogWarning("No author found with ID {AuthorId}", id);
//            }

//            return author;
//        }

//        public async Task<Author> UpdateAuthorAsync(Guid id, Author author)
//        {
//            _logger.LogInformation("Updating author with ID {AuthorId}", id);
//            var authorToUpdate = _realDatabase.Authors.FirstOrDefault(a => a.Id == id);
//            if (authorToUpdate != null)
//            {

//                authorToUpdate.Name = author.Name;
//                _realDatabase.SaveChanges();
//                _logger.LogInformation("Author with ID {AuthorId} updated successfully.", id);
//                return authorToUpdate;
//            }
//            _logger.LogWarning("Attempted to update author with ID {AuthorId}, but not found.", id);
//            return null;
//        }
//    }
//}
