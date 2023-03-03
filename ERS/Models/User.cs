using Models.CustomException;

namespace Models;

public class User
{
    public int ID { get; set; }
    private string _username, _password;
    public string FirstName { get; set; } = null;
    public string LastName { get; set; } = null;
    public string Username
    {
        get => _username;
        set => _username = value;
    }
    public string Password
    {
        get => _password;
        set => _password = value;
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