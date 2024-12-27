using Domain;

namespace Application.Interface.RepositoryInterface
{
    public interface IUserRepository
    {
        Task<User> GetUserByCredentialsAsync(string userName, string pasword);
        Task<List<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);

    }
}
