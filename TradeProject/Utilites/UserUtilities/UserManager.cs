using TradeProject.DataModels;

namespace TradeProject.Utilites.UserUtilities
{
    public class UserManager
    {
        private readonly User[] users = new User[5];
        private int index = 0;

        //When initialized / created
        public UserManager() 
        {
            if(FileOperations.ReadFile(DatabaseConnection.DATABASE_PATH) == null || 
                FileOperations.ReadFile(DatabaseConnection.DATABASE_PATH) == string.Empty)
            {
                //Do as usual
            }
            else
            {
                for (int i = 0; i < FileOperations.GetCount(DatabaseConnection.DATABASE_PATH) && i < users.Length; i++)
                {
                    string entry = FileOperations.GetEntry(DatabaseConnection.DATABASE_PATH, i);
                    users[i] = ConvertToUser(entry);
                }
            }

        }

        private User ConvertToUser(string entry)
        {

            string[] parts = entry.Split("|");
            return new User(parts[0], parts[1], parts[2], parts[3], parts[4]);
            
        }

        public void AddUser(User user)
        {
            if(users[0] == null)
            {
                if (index != users.Length - 1)
                {
                    users[index] = user;
                    index++;
                    FileOperations.WriteFile(DatabaseConnection.DATABASE_PATH, new string[] {user.ToString()});
                }
                else
                {
                    Logger.Log(index + "");
                }
            }
            else
            {
                if (index != users.Length - 1)
                {
                    users[index] = user;
                    index++;
                    AddUserToDatabase(user);
                }
                else
                {
                    Logger.Log(index + "");
                }
            }
        }

        private void AddUserToDatabase(User user)
        {
            FileOperations.AddToFile(DatabaseConnection.DATABASE_PATH, user.ToString());
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
