using Models;
using Models.CustomException;

namespace Tests;

public class UserTests
{
    [Fact]
    public void UserShouldCreate()
    {
        User u = new();

        Assert.NotNull(u);
        Assert.Null(u.FirstName);
        Assert.Null(u.LastName);
        Assert.NotNull(u.Rank);
    }

    [Fact]
    public void UserShouldSetValidusernameAndPassword()
    {
        User u = new();

        u.Username = "testme";
        u.Password = "password";
        u.ID = 1;
        Assert.Equal("testme", u.Username);
        Assert.Equal("1", u.ID.ToString());
        Assert.Equal("password", u.Password);
    }

    [Fact]
    public void UserToStringIsWorking()
    {
        User u = new();
        u.LastName = "Meji";
        Assert.Contains("Meji", u.ToString());
    }

    [Fact]
    public void UserFullNameIsWorking()
    {
        User u = new();
        u.FirstName = "Eng";
        u.LastName = "Meji";
        Assert.Equal("Eng Meji", u.GetFullName());
    }
}