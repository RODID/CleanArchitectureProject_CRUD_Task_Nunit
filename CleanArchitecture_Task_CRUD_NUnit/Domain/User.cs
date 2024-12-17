using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public User(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public User()
        {

        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
