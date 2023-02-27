using Models;
using Data;

namespace Services;
public class AccountService
{
    // Dependency Injection: is a design pattern where the dependency of a class is injected through the constructor instead of the class itself having a specific knowledge of its dependency, or instantiating itself
    // This example here is actually a combination of dependency injection and dependency inversion
    // This allows for more flexible change in implementation, also this pattern makes unit testing much simpler
    private readonly IRepository _repo;
    public AccountService(IRepository repo)
    {
        _repo = repo;
    }

    public List<Ticket> GetAllTickets()
    {
        return _repo.GetAllTickets();
    }

    public List<Ticket>? GetPendingTickets()
    {
        List<Ticket> allTickets = GetAllTickets();
        List<Ticket>? pendingTickets;
        try
        {
            pendingTickets = allTickets.Where(Ticket => Ticket.Status.Equals(0)).ToList();
        }
        catch (InvalidOperationException)
        {
            pendingTickets = null;
        }
        return pendingTickets;
    }

    public List<Ticket>? GetTicketsForUser(int UserID)
    {
        List<Ticket> allTickets = GetAllTickets();
        List<Ticket>? filteredTickets;
        try
        {
            filteredTickets = allTickets.Where(Ticket => Ticket.UserID.Equals(UserID)).ToList();
        }
        catch (InvalidOperationException)
        {
            filteredTickets = null;
        }
        return filteredTickets;
    }

    public void CreateNewTicket(Ticket newTicket)
    {
        // try
        //{
        _repo.CreateNewTicket(newTicket);
        //}
        // catch (SqlException)
        //{
        //  throw;
        // }
    }

    public void UpdateTicketStatus(int TicketID, int Status)
    {
        _repo.UpdateTicketStatus(TicketID, Status);
    }

    public List<User> GetAllUsers()
    {
        return _repo.GetAllUsers();
    }

    public Boolean UsernameExists(string username)
    {
        if (GetUserByUsername(username) != null)
        {
            return true;
        }
        return false;
    }

    public int GetUserCount()
    {
        List<User> allUsers = _repo.GetAllUsers();

        return allUsers.Count();
    }

    public User? GetUserByUsername(string username)
    {
        List<User> allUsers = _repo.GetAllUsers();
        User? filteredUser;
        try
        {
            filteredUser = allUsers.First(user => user.Username.ToUpper().Equals(username.ToUpper()));
        }
        catch (InvalidOperationException)
        {
            filteredUser = null;
        }
        return filteredUser;
    }

    public void CreateNewUser(User newUser)
    {
        // try
        // {
        _repo.CreateNewUser(newUser);
        // }
        //catch (SqlException)
        //{
        //    throw;
        // }
    }
}