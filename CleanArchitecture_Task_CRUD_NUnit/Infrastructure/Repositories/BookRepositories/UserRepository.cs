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

        public async Task<User> AddUserAsync(User user)
        {
            _realDatabase.Users.Add(user);
            await _realDatabase.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _realDatabase.Users.ToListAsync();
        }

        public async Task<User> GetUserByCredentialsAsync(string userName, string password)
        {
            return await _realDatabase.Users
                .FirstOrDefaultAsync(user => user.UserName == userName && user.Password == password);
        }

    }
}
