using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map
{
    public class User
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public User(string login, string password, bool admin)
        {
            Login = login;
            Password = password;
            Admin = admin;
        }
    }
}