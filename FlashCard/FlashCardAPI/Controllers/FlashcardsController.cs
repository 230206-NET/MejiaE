using Microsoft.AspNetCore.Mvc;
using Data;
using Models;

namespace FlashCardAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FlashcardsController : ControllerBase
{
    private readonly ILogger<FlashcardsController> _logger;
    private readonly Repository _repo;

    public FlashcardsController(ILogger<FlashcardsController> logger, Repository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    [HttpGet]
    public List<Flashcard> Get()
    {
        return _repo.GetFlashCards();
    }

    [HttpPost]
    public Flashcard Post(Flashcard flashcard)
    {
        return _repo.CreateFlashCard(flashcard);
    }

    [HttpGet("{id:int}")]
    public Flashcard Get(int id)
    {
        return _repo.GetFlashCard(id);
    }

    [HttpPut("{id:int}")]
    public Flashcard Put(int id, Flashcard flashcard)
    {
        return _repo.UpdateFlashCard(id, flashcard);
    }

    [HttpDelete("{id:int}")]
    public Flashcard Delete(int id)
    {
        return _repo.DeleteFlashCard(id);
    }
}
