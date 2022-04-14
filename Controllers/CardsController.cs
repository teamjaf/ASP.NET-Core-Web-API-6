using Card_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Card_Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CardsController : Controller
{
    private readonly CardsDbContext cardsDbContext;
    public CardsController(CardsDbContext cardsDbContext)
    {
        this.cardsDbContext = cardsDbContext;
    }
    
    // GET all cards
    [HttpGet]
    public async Task<IActionResult> GetAllCards()
    {
        var cards = await cardsDbContext.Cards.ToListAsync();
        return Ok(cards);
    }
    
    
}