using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCardProject.Models;

public interface ICardService
{
    Task<IEnumerable<Cards>> GetCardsAsync();
    Task<Cards> GetCardDetailsAsync(long cardNumber);
}
