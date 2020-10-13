using System;
using System.Collections.Generic;
using System.Linq;
using Assignment.Models;

namespace Assignment.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> Users;

        public InMemoryUserService()
        {
            Users = new[]
            {
                new User
                {
                    Password = "123456",
                    SecurityLevel = 5,
                    UserName = "Admin",
                    Role = "Admin"
                }
            }.ToList();
        }

        public User ValidateUser(string userName, string password)
        {
            User first = Users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}