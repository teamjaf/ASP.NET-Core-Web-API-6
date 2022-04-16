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
    [HttpGet] // Kills 2 hours for not implementing
    public async Task<IActionResult> GetAllCards()
    {
        var cards = await cardsDbContext.Cards.ToListAsync();
        return Ok(cards);
    }
    
    
    // Get single card
    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("GetCard")]
    public async Task<IActionResult> GetCard([FromRoute] Guid id)
    {
        var card = await cardsDbContext.Cards.FirstOrDefaultAsync(
            x => x.id == id);
        if (card != null)
        {
            return Ok(card);
        }
        return NotFound("Sorry, card did not found!");
    }

    
    // Add single card
    [HttpPost]
    [Route("{id:guid}")]
    public async Task<IActionResult> AddCard([FromBody] Models.Card card)
    {
      //  card.id = Guid.NewGuid();
        await cardsDbContext.Cards.AddAsync(card);
        await cardsDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCard), new {id = card.id}, card);
    }
    
// Updating a card
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCard([FromRoute]Guid id, [FromBody] Models.Card card)
    {
        var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(
            x => x.id == id);
        if (card != null)
        {
            existingCard.CardHolderName = card.CardHolderName;
            existingCard.CardNumber = card.CardNumber;
            existingCard.ExpiryMonth = card.ExpiryMonth;
            existingCard.ExpiryYear = card.ExpiryYear;
            existingCard.CVC = card.CVC;
            
            await cardsDbContext.SaveChangesAsync();

            return Ok(existingCard);
        }
        return NotFound("Card not found!");
    }


    // Deleting a card
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCard([FromRoute] Guid id)
    {
        var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(
            x => x.id == id);
        if (existingCard != null)
        {
            cardsDbContext.Remove(existingCard);
            await cardsDbContext.SaveChangesAsync();
            return Ok(existingCard);
        }
        return NotFound("Card not found!");
    }

}