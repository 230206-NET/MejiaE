using Models;
using Models.CustomException;

namespace Tests;

public class TicketTests
{
    [Fact]
    public void TicketShouldCreate()
    {
        Ticket t = new();

        Assert.NotNull(t);
        Assert.NotNull(t.SubmissionDate);
    }

    [Fact]
    public void TicketShouldSetValidDescriptionAndAmountAndUserId()
    {
        Ticket t = new();

        t.Amount = 49.99m;
        t.Description = "test desc";
        t.UserID = 0;
        Assert.Equal("test desc", t.Description);
        Assert.Equal("49.99", t.Amount.ToString());
        Assert.Equal("0", t.UserID.ToString());
    }

    [Fact]
    public void TicketToStringIsWorking()
    {
        Ticket t = new();
        t.Amount = 69.99m;
        Assert.Contains("69.99", t.ToString());
    }
}