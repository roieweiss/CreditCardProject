using Microsoft.AspNetCore.Mvc;
using CreditCardProject.Models;
using CreditCardProject.MockData;


namespace CreditCardProject.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardsController : ControllerBase
    {
        private readonly List<Cards> _cards;
        private readonly ICardService _cardService;

        public CardsController()
        {
            _cards = CardsData.Cards;
        }

        // GET: api/cards
        [HttpGet]
        public IActionResult GetCards()
        {
            return Ok(_cards); // Return all cards
        }


        // GET: api/cards/search
        [HttpGet("search")]
        public IActionResult SearchCards(bool? isBlock, long? cardNumber, string bankName)
        {
            try
            {
                // Filter cards based on search criteria
                var filteredCards = _cards.AsQueryable(); // Start with all cards

                if (isBlock.HasValue)
                {
                    filteredCards = filteredCards.Where(c => c.IsBlocked == isBlock);
                }

                if (cardNumber.HasValue)
                {
                    filteredCards = filteredCards.Where(c => c.CardNumber == cardNumber);
                }

                return Ok(filteredCards.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to search cards: {ex.Message}");
            }
        }
        [HttpPost("increase-limit")]
        public IActionResult IncreaseCardLimit(long cardNumber, [FromBody] IncreaseLimitRequest request)
        {
            try
            {
                var card = _cards.FirstOrDefault(c => c.CardNumber == cardNumber);
                if (card == null)
                {
                    return NotFound("Card not found");
                }
                card.IncreaseCreditLimit(request.RequestedLimit, request.EmploymentStatus, request.MonthlyIncome, request.MaxAllowedLimit);
                return Ok("Credit limit increased successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to increase credit limit: {ex.Message}");
            }
        }

        // POST: api/cards
        /* [HttpPost]
         public IActionResult AddCard([FromBody] Cards card)
         {
             try
             {
                 // Add the new card to the list
                 _cards.Add(card);
                 return Ok("Card added successfully");
             }
             catch (Exception ex)
             {
                 return BadRequest($"Failed to add card: {ex.Message}");
             }
         } */
    }
}
