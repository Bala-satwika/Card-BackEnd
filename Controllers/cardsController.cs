using apiAndAsp.data;
using apiAndAsp.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiAndAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cardsController : ControllerBase
    {
        private readonly cardDbContext cardDbContext;

        public cardsController(cardDbContext cardDbContext) 
        {
            this.cardDbContext=cardDbContext;
        }

        //get all cards
        [HttpGet]
        public async Task<IActionResult> GetAllcards()
        {
           var cards= await cardDbContext.cards.ToListAsync();
            return Ok(cards);
        }
        // to get sengle card
        [HttpGet("{id:guid}")]
        [ActionName("GetCard")]
        public async Task<IActionResult> Getcard([FromRoute] Guid id)
        {
            var cards = await cardDbContext.cards.FirstOrDefaultAsync(x=>x.Id==id);
            if (cards != null)
            {
                return Ok(cards);
            }
            return Ok(cards);
        }
        //add card
        [HttpPost]
        
        public async Task<IActionResult> Addcard([FromBody] card card)
        {
           card.Id=Guid.NewGuid();
          await  cardDbContext.cards.AddAsync(card);
            await cardDbContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Getcard),new {id=card.Id},card);
        }
        //update card
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Updatecard([FromRoute] Guid id, [FromBody] card card)
        {
            var existingcard = await cardDbContext.cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingcard != null)
            {
                existingcard.cardHolderName= card.cardHolderName;
                existingcard.cardNumber= card.cardNumber;
                existingcard.expiryMonth = card.expiryMonth;
                existingcard.expiryYear = card.expiryYear;
                existingcard.cvc = card.cvc;
                await cardDbContext.SaveChangesAsync();
                return Ok(existingcard);

            }
            return NotFound("card not found");

        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletecard([FromRoute] Guid id)
        {
            var existingcard = await cardDbContext.cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingcard != null)
            {
                cardDbContext.Remove(existingcard);
                await cardDbContext.SaveChangesAsync();
                return Ok(existingcard);

            }
            return NotFound("card not found");

        }

    }
}
