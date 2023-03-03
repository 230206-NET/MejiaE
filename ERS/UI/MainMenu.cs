using Data;

using Services;

namespace UI;

public class MainMenu
{
    // This is just dep injection
    private readonly AccountService _service;

    public MainMenu(AccountService service)
    {
        _service = service;
    }
    public void Start()
    {

        while (true)
        {
            string username, password;
            User currentUser;

            Console.WriteLine(UIWindow.initScreen);
            Console.Write("=> ");

            string? input = Console.ReadLine();
            switch (input?.ToUpper())
            {
                case "1":
                    Console.WriteLine("Username:");
                    username = getUsernameInput();

                    Console.WriteLine("Password:");
                    password = getPasswordInput();

                    Console.Clear();
                    Console.WriteLine("Attempting to log in...");

                    bool success = attemptLogin(username, password, out currentUser);

                    if (success)
                    {
                        AccountPanel AP = new AccountPanel(_service, currentUser);
                        AP.Start();
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("""
                                        ACCOUNT REGISTRATION
                                        ====================
                                        """);
                    Console.WriteLine("Username:");
                    username = getUsernameInput();

                    string[] passwordsToCompare = new string[2];
                    for (int i = 0; i < passwordsToCompare.Length; i++)
                    {
                        Console.WriteLine(i > 0 ? "Re-enter Password:" : "Password:");
                        passwordsToCompare[i] = getPasswordInput();
                    }

                    string? fName, lName;

                    Console.WriteLine("First name:");
                    fName = Console.ReadLine();

                    Console.WriteLine("Last name:");
                    lName = Console.ReadLine();

                    if (_service.UsernameExists(username))
                    {
                        Console.WriteLine("That username is already in use, please try again!");
                    }
                    else if (!CompareStrings(passwordsToCompare[0], passwordsToCompare[1]))
                    {
                        Console.WriteLine("Passwords do not match, please try again!");
                    }
                    else
                    {
                        try
                        {
                            User newUser = new User
                            {
                                FirstName = fName,
                                LastName = lName,
                                Username = username,
                                Password = passwordsToCompare[0],
                                //Rank = _service.GetUserCount() > 0 ? 0 : 1 this makes sense but gotta follow user stories...
                            };
                            _service.CreateNewUser(newUser);
                            Console.Clear();
                            Console.WriteLine("User has been created, please log in!");
                        }
                        catch (ArgumentLengthException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    break;

                case "X":
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again!");
                    break;
            }
        }
    }

    private Boolean CompareStrings(string firstPassword, string secondPassword)
    {
        if (firstPassword.Equals(secondPassword))
        {
            return true;
        }
        return false;
    }
    private Boolean attemptLogin(string username, string password, out User user)
    {

        user = _service.GetUserByUsername(username);

        if (user == null)
        {
            Console.WriteLine("Account does not exist, did you mean to register an account?");
        }
        else if (CompareStrings(user.Password, password))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Invalid password!");

        }
        return false;
    }

    private string getUsernameInput()
    {
        string username = Console.ReadLine();
        return username;
    }

    private string getPasswordInput()
    {
        string password = "";

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password.Remove(password.Length - 1, 1);
            }
            else if (!char.IsControl(key.KeyChar))
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine("\n");

        return password;
    }

}
