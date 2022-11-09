using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProject.DataModels;

namespace TradeProject.Utilites.Database
{
    public class DatabaseOperations
    {
        public static User ConvertStringToUser(string entry)
        {
            string[] parts = entry.Split("|");
            return new User(parts[0], parts[1], parts[2], parts[3], parts[4]);

        }
        public static void AddUserToDatabase(User user)
        {
            FileOperations.AddToFile(DatabaseConnection.DATABASE_PATH, user.ToString());
        }

    }
}
