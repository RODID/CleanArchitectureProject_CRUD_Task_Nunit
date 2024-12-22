using Application.Interface.RepositoryInterface;
using Domain;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase) 
        {
            _realDatabase = realDatabase; 
        }

        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByCredentialsAsync(string userName, string password)
        {
            var hashedPassword = HashPassword(password); // If you're hashing passwords
            return await _realDatabase.Users
                .FirstOrDefaultAsync(user => user.UserName == userName && user.Password == hashedPassword);
        }

        // Example of a hashing function if you are storing hashed passwords
        private string HashPassword(string password)
        {
            // Implement your hashing logic here, e.g., using SHA256 or BCrypt
            return password; // Replace with actual hash logic
        }
    }
}
