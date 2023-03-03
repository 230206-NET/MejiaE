using Services;

namespace UI;

public class AccountPanel
{
    private readonly AccountService _service;
    private readonly User _user;

    private Boolean logout = false;

    public AccountPanel(AccountService service, User user)
    {
        _service = service;
        _user = user;
    }

    public void Start()
    {

        while (!logout)
        {
            Console.WriteLine($"Welcome, {_user.Username}");
            Console.WriteLine(UIWindow.accountScreen[_user.Rank]);
            Console.Write("=> ");

            string? input = Console.ReadLine();
            switch (input?.ToUpper())
            {
                case "1":
                    if (_user.Rank.Equals(0))
                    {
                        TicketPrompt();
                    }
                    else if (_user.Rank.Equals(1))
                    {
                        DisplayPendingTickets();
                    }
                    break;
                case "2":
                    if (_user.Rank.Equals(0))
                    {
                        DisplayUserTickets();
                    }
                    else if (_user.Rank.Equals(1))
                    {

                    }
                    break;
                case "X":
                    logout = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again!");
                    break;
            }

        }
    }

    public void TicketPrompt()
    {
        while (true)
        {
            Console.WriteLine("Enter your ticket Description:");
            string tDescription = Console.ReadLine();

            Console.WriteLine("Enter your ticket amount:");
            decimal tAmount;
            bool success = decimal.TryParse(Console.ReadLine(), out tAmount);
            if (success)
            {
                try
                {
                    Ticket newTicket = new Ticket
                    {
                        Description = tDescription,
                        Amount = tAmount,
                        UserID = _user.ID
                    };
                    _service.CreateNewTicket(newTicket);
                    Console.Clear();
                    Console.WriteLine("Ticket has been created! Would you like to add another one? (Y/N)");
                    string ans = Console.ReadLine();
                    if (ans.ToUpper().Equals("Y"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentLengthException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input for amount... Please try again!");
            }
        }
    }

    public void DisplayPendingTickets()
    {
        List<Ticket> pendingTickets = _service.GetPendingTickets();
        if (pendingTickets == null || pendingTickets.Count() == 0)
        {
            Console.WriteLine("Congratulations! There are no pending tickets.");
        }
        else
        {
            while (pendingTickets.Count() > 0)
            {
                Console.WriteLine("Current tickets pending:");
                foreach (Ticket ticket in pendingTickets)
                {
                    Console.WriteLine(ticket.ToString());
                }
                Console.WriteLine("Which ticket would you like to work on? (Enter ID):");
                int input;
                bool success = int.TryParse(Console.ReadLine(), out input);
                if (!success)
                {
                    Console.WriteLine("Please input a valid number!");
                    continue;
                }
                bool ticketExists = pendingTickets.Any(ticket => ticket.ID == input);
                if (ticketExists)
                {
                    Console.WriteLine("Would you like to accept or deny this ticket? (A/D):");
                    string? choice = Console.ReadLine();
                    switch (choice.ToUpper())
                    {
                        case "A":
                        case "D":
                            _service.UpdateTicketStatus(input, choice.ToUpper().Equals("A") ? 1 : 2);
                            pendingTickets.RemoveAll(ticket => ticket.ID == input);
                            Console.WriteLine("Ticket status has been updated successfully.");
                            break;
                        default:
                            Console.WriteLine("Invalid input, please try again!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("That's not a valid ticket ID, please try again!");
                }
            }
        }

    }
    public void DisplayUserTickets()
    {
        List<Ticket> userTickets = _service.GetTicketsForUser(_user.ID);
        if (userTickets == null || userTickets.Count() == 0)
        {
            Console.WriteLine("You haven't submitted any tickets.");
        }
        else
        {
            Console.WriteLine("Your current tickets:");
            foreach (Ticket ticket in userTickets)
            {
                Console.WriteLine(ticket.ToString());
            }
        }

    }
}