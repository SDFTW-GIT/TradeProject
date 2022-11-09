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

        //Full Constructor
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

        public string GetDetails()
        {
            return "First Name: " + firstName +
                "\nLast Name: " + lastName +
                "\nEmail: " + email +
                "\n\nDescription: " + description;
        }

        public override string ToString()
        {
            return firstName + "|" + lastName +
                "|" + email + 
                "|" + password +
                "|" + description;
        }
    }
}
