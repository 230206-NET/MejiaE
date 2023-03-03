using Models;
using System.Collections.Generic;
namespace Data;
public interface IRepository
{
    /// <summary>
    /// Retrieves all tickets
    /// </summary>
    /// <returns>a PriorityQueue of tickets</returns>
    List<Ticket> GetAllTickets();

    /// <summary>
    /// Persists a new ticket to storage
    /// </summary>
    void CreateNewTicket(Ticket newTicket);

    /// <summary>
    /// Retrieves all users
    /// </summary>
    /// <returns>a List of users</returns>
    List<User> GetAllUsers();

    /// <summary>
    /// Persists a new ticket to storage
    /// </summary>
    void CreateNewUser(User newUser);

    void UpdateTicketStatus(int TicketID, int Status);
}