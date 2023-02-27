using Models.CustomException;

namespace Models;

public class User
{
    public int ID { get; set; }
    private string _firstName, _lastName, _username, _password;
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (value.Length > 20 || value.Length < 3 && !string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentLengthException("First name must be 3 to 20 characters long");
            }
            else
            {
                _firstName = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }
    }
    public string LastName
    {
        get => _lastName;
        set
        {
            if (value.Length > 20 || value.Length < 3 && !string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentLengthException("Last name must be 3 to 20 characters long");
            }
            else
            {
                _lastName = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }
    }
    public string Username
    {
        get => _username;
        set
        {
            if (value.Length > 20 || value.Length < 3 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentLengthException("Username must be 3 to 20 characters long");
            }
            else
            {
                _username = value;
            }
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            if (value.Length > 100 || value.Length < 8 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentLengthException("Passwords must be between 8 and 100 characters long.");
            }
            else
            {
                _password = value;
            }
        }
    }
    public int Rank { get; set; } = 0;

    public string GetFullName()
    {
        return $"{this.FirstName} {this.LastName}";
    }

    public override string ToString()
    {
        return $"""
            ID: {this.ID}
            Name:{this.FirstName} {this.LastName}
            Username:{this.Username}
            Rank: {this.Rank}
            """;
    }

}