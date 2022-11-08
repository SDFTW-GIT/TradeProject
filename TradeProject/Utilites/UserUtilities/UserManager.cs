using TradeProject.DataModels;

namespace TradeProject.Utilites.UserUtilities
{
    public class UserManager
    {
        private readonly User[] users = new User[2];
        private int index = 0;

        public void AddUser(User user)
        {
            if (index != users.Length - 1)
            {
                users[index] = user;
                index++;
            }
            else
            {
                Logger.Log(index + "");
            }
        }

        public User GetUserByPasswordAndEmail(string email, string password) 
        {
            User temp = null;

            for(int i = 0; i < users.Length; i++)
            {
                if (users[i] != null)
                    if (users[i].GetPassword().Equals(password) &&
                        users[i].GetEmail().Equals(email))
                    {
                        temp = users[i];
                    }
            }

            return temp;
        }

        public User[] GetUsers()
        {
            return users;
        }
    }
}
