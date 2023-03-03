using Models;
using Models.CustomException;

namespace Tests;

public class LoginCredentialsTests
{
    [Fact]
    public void LoginCredentialsShouldCreate()
    {
        LoginCredentials lc = new LoginCredentials("test", "password");

        Assert.NotNull(lc);
        Assert.NotNull(lc.username);
        Assert.NotNull(lc.password);
    }
}