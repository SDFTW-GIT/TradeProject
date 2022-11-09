using TradeProject.DataModels;
using TradeProject.Utilites;
using TradeProject.Utilites.UserUtilities;

UserManager userManager = new();
UserVerifier userVerifier = new(userManager);

bool running = false;

//Testing
Console.Write(FileOperations.ReadFile(DatabaseConnection.DATABASE_PATH));
Console.WriteLine(FileOperations.GetCount(DatabaseConnection.DATABASE_PATH));
Thread.Sleep(7000);

//Start of Program
while (true)
{
    Logger.Log("Start Program? (Y/N)");
    char key = Console.ReadKey(true).KeyChar;

    //Answer was Yes
    if (key == 'Y' || key == 'y')
    {
        running = true;
        Console.Clear();
        Logger.Log("Starting Program...");
        Thread.Sleep(1000);
        Console.Clear();
        break;
    }
    //Answer was No
    else if (key == 'N' || key == 'n')
    {
        Console.Clear();
        Logger.Log("Ending...");
        Thread.Sleep(1000);
        break;
    }
    //Incorrect input
    else
    {
        Logger.Log("\'" + key + "\' wasn't a correct input, try again...");
        Thread.Sleep(1000);
        Console.Clear();
    }
}

//Introduction for the home/landing page
string introduction =
    "Welcome to the Trading Platform!\n\n" +
    "Here are your following options:\n" +
    "1. Sign Up\n" +
    "2. Log In\n" +
    "3. Exit\n\n" +
    "Please enter your selection. (1, 2, or 3)";

//Program
while (running == true)
{
    Logger.Log(introduction);
    char key = Console.ReadKey(true).KeyChar;
    Console.Clear();

    //Sign-up
    if (key == '1')
    {
        string firstName;
        string lastName;
        string description;
        string email;
        string password;

        //First Name
        while (true)
        {
            Logger.Log("Enter your First Name:");

            string? temp = Console.ReadLine();

            if (temp == null || temp == string.Empty)
            {
                Logger.Log("Your input was empty, try again...");
                Thread.Sleep(1500);
                Console.Clear();
            }
            else
            {
                firstName = temp;
                break;
            }
        }

        //Last Name
        while (true)
        {
            Logger.Log("Enter your Last Name:");

            string? temp = Console.ReadLine();

            if (temp == null || temp == string.Empty)
            {
                Logger.Log("Your input was empty, try again...");
                Thread.Sleep(1500);
                Console.Clear();
            }
            else
            {
                lastName = temp;
                Console.Clear();
                break;
            }
        }

        //Description
        while (true)
        {
            Logger.Log("Enter some text about yourself:");

            string? temp = Console.ReadLine();

            if (temp == null || temp == string.Empty)
            {
                Logger.Log("Your input was empty, try again...");
                Thread.Sleep(1500);
                Console.Clear();
            }
            else
            {
                description = temp;
                Console.Clear();
                break;
            }
        }

        //Email
        while (true)
        {
            Logger.Log("Enter your email:");

            string? temp = Console.ReadLine();

            if (temp == null || temp == string.Empty)
            {
                Logger.Log("Your input was empty, try again...");
                Thread.Sleep(1500);
                Console.Clear();
            }
            else
            {
                email = temp;
                Console.Clear();
                break;
            }
        }

        //Password
        while (true)
        {
            Logger.Log("Enter a password:");

            string? temp = Console.ReadLine();

            if (temp == null || temp == string.Empty)
            {
                Logger.Log("Your input was empty, try again...");
                Thread.Sleep(1500);
                Console.Clear();
            }
            else
            {
                password = temp;
                Console.Clear();
                break;
            }
        }

        //Successful creation of a new user.
        userManager.AddUser(new User(firstName, lastName, email, password, description));
        Logger.Log("User Added!");
        Thread.Sleep(1500);
        Console.Clear();
    }

    //Logging-In
    else if (key == '2')
    {
        string? email;
        string? password;

        Logger.Log("Enter your email:");
        email = Console.ReadLine();

        Logger.Log("Enter your password:");
        password= Console.ReadLine();

        if(userVerifier.IsLoginVerified(email, password))
        {
            Logger.Log("Login Verified!");
            Thread.Sleep(2000);
            Console.Clear();

            //Login was successful
            User temp = userManager.GetUserByPasswordAndEmail(email, password);

            if (temp!=null)
            {
                string message =
                "Welcome " + temp.GetFirstName() + " " + temp.GetLastName() +
                "\n\nWhat would you like to do?\n" +
                "1. View Profile\n" +
                "2. Create Trade\n" +
                "3. See Global Trades\n" +
                "4. ";

                Logger.Log(message);

                char input = Console.ReadKey(true).KeyChar;

                //View Profile
                if (input == '1')
                {   
                    Console.Clear();
                    Logger.Log(temp.GetDetails());
                    Logger.Log("Press enter to exit");
                    Console.Read();
                }
            }  
        }
        else
        {
            Logger.Log("Login couldn't be verified!");
        }
    }
    //Exiting
    else if(key == '3')
    {
        Logger.Log("Exiting...");
        Thread.Sleep(1500);
        break;
    }
    //Incorrect Input
    else
    {
        Logger.Log("\'" + key + "\' wasn't a correct input, try again...");
        Thread.Sleep(2000);
        Console.Clear();
    }
}