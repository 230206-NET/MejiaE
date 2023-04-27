using Models;

namespace Data;
public class Repository
{
    private readonly FlashcardDbContext _context;

    public Repository(FlashcardDbContext context)
    {
        _context = context;
    }


    public List<Flashcard> GetFlashCards()
    {
        return _context.Flashcards.ToList();
    }

    public Flashcard CreateFlashCard(Flashcard flashcard)
    {
        _context.Add(flashcard);
        _context.SaveChanges();

        return flashcard;
    }

    public Flashcard GetFlashCard(int Id)
    {
        return _context.Flashcards.Find(Id);
    }

    public Flashcard UpdateFlashCard(int Id, Flashcard flashcard)
    {
        Flashcard card = GetFlashCard(Id);
        if (card != null)
        {
            _context.ChangeTracker.Clear();
            flashcard.Id = Id;
            _context.Update(flashcard);
            _context.SaveChanges();

            return flashcard;
        }
        
        return card;
    }

    public Flashcard DeleteFlashCard(int Id)
    {
        Flashcard card = GetFlashCard(Id);
        if (card != null)
        {
            _context.Remove(card);
            _context.SaveChanges();
        }
        return card;
    }

}
