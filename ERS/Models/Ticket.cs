using Models.CustomException;

namespace Models;

public class Ticket
{
    public int ID { get; set; }
    private string _description;
    private decimal _amount;
    public string Description
    {
        get => _description;
        set => _description = value;
    }
    public decimal Amount
    {
        get => _amount;
        set => _amount = value;

    }
    public DateTime SubmissionDate { get; set; } = DateTime.Now;
    public int UserID { get; set; }
    public int Status { get; set; } = 0;
    public int Category { get; set; } = 0;

    private string[] statusToString = { "Pending", "Accepted", "Declined" };


    public override string ToString()
    {
        return $"""
            ID: {this.ID} | Description: {this.Description} | Amount: {this.Amount} | Date: {this.SubmissionDate} | Status: {statusToString[this.Status]}
            """;
    }

}