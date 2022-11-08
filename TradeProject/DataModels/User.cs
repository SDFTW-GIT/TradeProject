using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeProject.DataModels
{
    public class User
    {
        //Class Variable
        private static int id = 0;

        //Class Attributes
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string description;

        //Default Constructor
        public User(string firstName, string lastName, string email, string password, string description)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.description = description;
            id++;
        }

        //Getters
        public string GetFirstName() { return firstName; }
        public string GetLastName() { return lastName; }
        public string GetEmail() { return email; }
        public string GetPassword() { return password; }
        public string GetDescription() { return description; }
        public int GetId() { return id; }

        public override string ToString()
        {
            return "Name: "+firstName + " " + lastName +
                "\nEmail: " + email + 
                "\nDescription: " + description;
        }
    }
}
