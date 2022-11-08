using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProject.DataModels;

namespace TradeProject.Utilites.UserUtilities
{
    public class UserManager
    {
        private readonly User[] users = new User[100];
        private int index = 0;

        public void AddUser(User user)
        {
            if (index != users.Length - 1)
            {
                users[index] = user;
                index++;
            }
        }

        public User[] GetUsers()
        {
            return users;
        }
    }
}
