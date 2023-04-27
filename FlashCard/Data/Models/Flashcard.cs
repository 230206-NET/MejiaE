using System.ComponentModel.DataAnnotations;

namespace Models;
public class Flashcard
{
    public int Id {get; set;}

    [Required]
    [MaxLength(1000)]
    public string Question {get; set;}

    [Required]
    [MaxLength(1000)]
    public string Answer {get; set;}
}