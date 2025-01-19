//using Application.Interface.RepositoryInterface;
//using Domain;
//using Infrastructure.Database;
//using Microsoft.EntityFrameworkCore;

//namespace Infrastructure.Repositories.BookRepositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly RealDatabase _realDatabase;

//        public UserRepository(RealDatabase realDatabase) 
//        {
//            _realDatabase = realDatabase; 
//        }

//        public async Task<User> AddUserAsync(User user)
//        {
//            _realDatabase.Users.Add(user);
//            _realDatabase.SaveChanges();
//            return user;
//        }

//        public async Task<List<User>> GetAllUsersAsync()
//        {
//            var user = await Task.FromResult(_realDatabase.Users.ToList());
//            return user;
//        }

//        public async Task<User> LoginUser(string userName, string pasword)
//        {
//            var user = await _realDatabase.Users.FirstOrDefaultAsync( u => u.UserName == userName
//                && u.Password == pasword );
//            return user;
//        }
//    }
//}
