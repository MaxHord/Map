using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Model
{
    class UserCreate
    {
        public HashSet<User> Users { get; private set; }
        private static UserCreate userStorage;

        public static UserCreate GetUser()
        {
            return userStorage= new UserCreate();
        }

        private UserCreate()
        {
            Users = new HashSet<User>
            {
                new User("admin","admin",true),
                new User("user","user",false)
            };
        }

        public User SearchUser(string login, string password)
        {
                User user = (from u in Users
                             where u.Login.Equals(login)
                             && u.Password.Equals(password)
                             select u).FirstOrDefault();
            return user;
        }
    }
}
