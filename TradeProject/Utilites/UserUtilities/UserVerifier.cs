using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProject.DataModels;

namespace TradeProject.Utilites.UserUtilities
{
    public class UserVerifier
    {
        private readonly UserManager userManager;

        public UserVerifier(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public bool IsLoginVerified(string? email, string? password)
        {
            bool success = false;

            for (int i = 0; i < userManager.GetUsers().Length; i++)
            {
                if (userManager.GetUsers()[i] != null)
                    if (IsUserMatchingRequirements(userManager.GetUsers()[i], email, password))
                    {
                        success = true;
                    }
            }

            return success;
        }

        private bool IsUserMatchingRequirements(User user, string? email, string? password)
        {
            if (IsEmailMatchingUsers(user, email) == true &&
                IsPasswordMatchingUsers(user, password) == true)
            { return true; }
            else
            { return false; }
        }

        private bool IsEmailMatchingUsers(User user, string? email)
        {
            if (user.GetEmail().Equals(email)) { return true; }
            else return false;
        }

        private bool IsPasswordMatchingUsers(User user, string? password)
        {
            if (user.GetPassword().Equals(password)) { return true; }
            else return false;
        }
    }
}
