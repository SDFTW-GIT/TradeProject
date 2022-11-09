using TradeProject.DataModels;
using TradeProject.Utilites.Database;

namespace TradeProject.Utilites.Users
{
    public class UserManager
    {
        private readonly string database_path = DatabaseConnection.DATABASE_PATH;

        private readonly User[] users;
        private int index;

        //When initialized / created
        public UserManager() 
        {


            if(FileOperations.GetFileContents(database_path) == null || 
                FileOperations.GetFileContents(database_path) == string.Empty)
            {
                //No entries
                users = new User[10];
                index = 0;
            }
            else
            {
                //Initialize the array if there are entries
                users = new User[FileOperations.GetCount(database_path)+10];
                index = users.Length-10;

                for (int i = 0; i < FileOperations.GetCount(database_path) && i < users.Length; i++)
                {
                    string entry = FileOperations.GetEntry(database_path, i);
                    users[i] = DatabaseOperations.ConvertStringToUser(entry);
                }
            }

        }

        public void AddUser(User user)
        {
            if(users[0] == null)
            {
                if (index != users.Length - 1)
                {
                    users[index] = user;
                    index++;
                    //Add the user to the database
                    FileOperations.WriteFile(database_path, new string[] {user.ToString()});
                    Logger.Log("Added a new user to a empty database!");
                    Thread.Sleep(3000);
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
                    DatabaseOperations.AddUserToDatabase(user);
                    Logger.Log("Added a new user to the database!");
                    Thread.Sleep(3000);
                }
                else
                {
                    Logger.Log(index + "");
                }
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
