using Models;
using System.Data.SqlClient;

namespace Data;

public class DBRepository : IRepository
{
    /// <summary>
    /// Retrieves all tickets
    /// </summary>
    /// <returns>a List of tickets</returns>
    public List<Ticket> GetAllTickets()
    {
        List<Ticket> allTickets = new();

        using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
        conn.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Tickets", conn);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            allTickets.Add(new Ticket
            {
                ID = (int)reader["ID"],
                Description = (string)reader["TicketDescription"],
                Amount = (decimal)reader["Amount"],
                SubmissionDate = (DateTime)reader["SubmissionDate"],
                Status = (int)reader["TicketStatus"],
                Category = (int)reader["Category"],
                UserID = (int)reader["UserID"]
            }
            );
        }
        return allTickets;

    }

    /// <summary>
    /// Persists a new ticket to storage
    /// </summary>
    public void CreateNewTicket(Ticket newTicket)
    {
        using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
        conn.Open();

        using SqlCommand cmd = new SqlCommand("INSERT into Tickets(TicketDescription, Amount, SubmissionDate, TicketStatus, Category, UserID) Values (@Description, @Amount, @SubmissionDate, @Status, @Category, @UserID)", conn);
        cmd.Parameters.AddWithValue("@Description", newTicket.Description);
        cmd.Parameters.AddWithValue("@Amount", newTicket.Amount);
        cmd.Parameters.AddWithValue("@SubmissionDate", newTicket.SubmissionDate);
        cmd.Parameters.AddWithValue("@Status", newTicket.Status);
        cmd.Parameters.AddWithValue("@Category", newTicket.Category);
        cmd.Parameters.AddWithValue("@UserID", newTicket.UserID);

        cmd.ExecuteNonQuery();
    }

    public void UpdateTicketStatus(int TicketID, int Status)
    {
        using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
        conn.Open();

        using SqlCommand cmd = new SqlCommand("UPDATE Tickets SET TicketStatus = @TicketStatus Where ID = @ID", conn);
        cmd.Parameters.AddWithValue("@TicketStatus", Status);
        cmd.Parameters.AddWithValue("@ID", TicketID);

        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Retrieves all users
    /// </summary>
    /// <returns>a List of users</returns>

    /*
    
    public int ID { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Rank { get; set; }
    */
    public List<User> GetAllUsers()
    {
        List<User> allUsers = new();

        using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
        conn.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            allUsers.Add(new User
            {
                ID = (int)reader["ID"],
                FirstName = reader["FirstName"] == DBNull.Value ? "" : (string)reader["FirstName"],
                LastName = reader["LastName"] == DBNull.Value ? "" : (string)reader["LastName"],
                Username = (string)reader["Username"],
                Password = (string)reader["UserPassword"],
                Rank = (int)reader["Rank"]
            }
            );
        }
        return allUsers;
    }

    /// <summary>
    /// Persists a new ticket to storage
    /// </summary>
    public void CreateNewUser(User newUser)
    {
        using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
        conn.Open();

        using SqlCommand cmd = new SqlCommand("INSERT into Users(FirstName, LastName, Username, UserPassword, Rank) Values (@FirstName, @LastName, @Username, @UserPassword, @Rank)", conn);
        cmd.Parameters.AddWithValue("@FirstName", newUser.FirstName == null ? DBNull.Value : newUser.FirstName);
        cmd.Parameters.AddWithValue("@LastName", newUser.LastName == null ? DBNull.Value : newUser.LastName);
        cmd.Parameters.AddWithValue("@Username", newUser.Username);
        cmd.Parameters.AddWithValue("@UserPassword", newUser.Password);
        cmd.Parameters.AddWithValue("@Rank", newUser.Rank);

        cmd.ExecuteNonQuery();
    }
}