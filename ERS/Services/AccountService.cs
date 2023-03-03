using Models;
using Models.CustomException;
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
    public List<Ticket>? GetPendingTicketsForUser(int UserID)
    {
        List<Ticket> allTickets = GetAllTickets();
        List<Ticket>? filteredTickets;
        try
        {
            filteredTickets = allTickets.Where(Ticket => Ticket.UserID.Equals(UserID) && Ticket.Status.Equals(0)).ToList();
        }
        catch (InvalidOperationException)
        {
            filteredTickets = null;
        }
        return filteredTickets;
    }

    public Ticket CreateNewTicket(Ticket newTicket)
    {
        // try
        //{
        if (newTicket.Description.Length > 100 || newTicket.Description.Length < 3 || string.IsNullOrWhiteSpace(newTicket.Description))
        {
            throw new ArgumentLengthException("Description must be 3 to 20 characters long.");
        }
        else if (newTicket.Amount <= 0.0m)
        {
            throw new FormatException("Amount must be a valid number higher than 0.");
        }
        else
        {
            _repo.CreateNewTicket(newTicket);
            return newTicket;
        }
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

    public Ticket UpdateTicketStatusWithAuthorId(int editorId, int TicketId, int TicketStatus)
    {
        User editor = GetUserById(editorId);

        if (editor == null || editor.Rank != 1)
        {
            return null;
        }

        Ticket ticketToEdit = GetTicketById(TicketId);

        if (ticketToEdit != null && ticketToEdit.Status == 0)
        {
            UpdateTicketStatus(ticketToEdit.ID, TicketStatus);
            return GetTicketById(ticketToEdit.ID);
        }
        else
        {
            return null;
        }
    }

    public Ticket GetTicketById(int Id)
    {
        List<Ticket> allTickets = _repo.GetAllTickets();
        Ticket? filteredTicket;
        try
        {
            filteredTicket = allTickets.First(ticket => ticket.ID.Equals(Id));
        }
        catch (InvalidOperationException)
        {
            filteredTicket = null;
        }
        return filteredTicket;
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

    public Boolean AttemptLogin(string username, string password)
    {

        User user = GetUserByUsername(username);

        if (user == null)
        {
            return false;
        }
        else if (user.Password.Equals(password))
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

    public User? GetUserById(int id)
    {
        List<User> allUsers = _repo.GetAllUsers();
        User? filteredUser;
        try
        {
            filteredUser = allUsers.First(user => user.ID.Equals(id));
        }
        catch (InvalidOperationException)
        {
            filteredUser = null;
        }
        return filteredUser;
    }

    public User CreateNewUser(User newUser)
    {
        // try
        // {
        if (newUser.Username.Length > 20 || newUser.Username.Length < 3 || string.IsNullOrWhiteSpace(newUser.Username))
        {
            throw new ArgumentLengthException("Username must be 3 to 20 characters long.");
        }
        else if (newUser.Password.Length > 100 || newUser.Password.Length < 8 || string.IsNullOrWhiteSpace(newUser.Password))
        {
            throw new ArgumentLengthException("Passwords must be between 8 and 100 characters long.");
        }
        else if (UsernameExists(newUser.Username))
        {
            throw new UserAlreadyExistsException("That username is already taken.");
        }
        else
        {
            _repo.CreateNewUser(newUser);
            return newUser;
        }

        // }
        //catch (SqlException)
        //{
        //    throw;
        // }
    }
}