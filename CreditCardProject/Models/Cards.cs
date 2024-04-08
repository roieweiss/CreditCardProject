namespace CreditCardProject.Models
{
    public class Cards
    {
        private string _name;
        private long _cardNumber;
        private DateTime _validDate;
        private string _cardImage;
        private bool _isBlocked = false;
        private bool _isDigital;
        private decimal _cardLimit;
        private int _bankCode;

        // just to read card info
        public string Name { get { return _name; } }
        public long CardNumber { get { return _cardNumber; } }
        public DateTime ValidDate { get { return _validDate; } }
        public string CardImage { get { return _cardImage; } }
        public bool IsBlocked { get { return _isBlocked; } }
        public bool IsDigital { get { return _isDigital; } }

        // Controlled update for credit limit
        public decimal CardLimit { get { return _cardLimit; } }
        private bool IsValidCardLimit(int cardLimit)
        {
            // check that the card limit isnt negative
            return cardLimit >= 0;
        }
        public void UpdateCardNumber(long newCardNumber)
        {
            // Check if the new card number is valid
            if (newCardNumber == 16)
            {
                _cardNumber = newCardNumber; // Update the card number
            }
            else
            {
                throw new ArgumentException("Invalid card number"); // Throw exception if the new card number is invalid
            }
        }

        public void UpdateCardLimit(int newLimit)
        {
            // check the new card limit
            if (!IsValidCardLimit(newLimit))
            {
                throw new ArgumentException("Invalid card limit. Card limit must be 0 ore above.");
            }

            // card limit update securely
            try
            {
                _cardLimit = newLimit;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to update card limit securely.", ex);
            }
        }

        

        // try to make the BankCode more secure code
        public int BankCode { get { return _bankCode; } }
            private bool IsValidBankCode(int bankCode)
            {
                // checking that the BankCode will be 3 numbers
                string bankCodeStr = bankCode.ToString();
                return bankCodeStr.Length == 3 && int.TryParse(bankCodeStr, out _);
            }

        private bool CanUpdateBankCode()
        {
            // added logic to see if the bank code can really be updated (3 numbers, another check)
            return _bankCode == 3;
        }
        public void UpdateBankCode(int newBankCode)
        {
            // valid the new bank code
            if (!IsValidBankCode(newBankCode))
            {
                throw new ArgumentException("Invalid bank code. Bank code must be a 3-digit number.");
            }

            // valid that the bank code can be updated
            if (!CanUpdateBankCode())
            {
                throw new InvalidOperationException("Bank code cannot be updated.");
            }

            //bank code update securely
            try
            {
                _bankCode = newBankCode;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to update bank code securely.", ex);
            }
        }


       
        public Cards(string name, long cardNumber, DateTime validDate, string cardImage, bool isBlocked, bool isDigital, decimal cardLimit, int bankCode)
        {
            _name= name;
            _cardNumber = cardNumber;
            _validDate = validDate;
            _cardImage = cardImage;
            _isBlocked = isBlocked;
            _isDigital = isDigital;
            _cardLimit = cardLimit;
            _bankCode = bankCode;
        }


        private List<Cards> _cards;
        public Cards(List<Cards> cards)
        {
            _cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }
        // method to get a read-only copy of the list of cards
        public IReadOnlyList<Cards> GetCards()
        {
            // return a read-only scopy of the list
            return _cards.ToList().AsReadOnly();
        }

        private decimal GetMaximumAllowedLimit(string employmentStatus, decimal monthlyIncome)
        {
            switch (employmentStatus)
            {
                case "Employee":
                    return monthlyIncome / 2;
                case "Independent":
                    return monthlyIncome / 3;
                default:
                    throw new InvalidOperationException("Unsupported employment status.");
            }
        }
        public void IncreaseCreditLimit(decimal requestedLimit, string employmentStatus, decimal monthlyIncome, decimal maxAllowedLimit)
        {
            if (!IsBlocked)
            {
                throw new InvalidOperationException("Cannot increase credit limit for a blocked card.");
            }

            if (monthlyIncome < 12000)
            {
                throw new ArgumentOutOfRangeException(nameof(monthlyIncome), "Monthly income must be at least 12,000.");
            }

            if ((DateTime.Now - ValidDate).TotalDays <= 90)
            {
                throw new InvalidOperationException("Cannot increase credit limit within 3 months of card issuance.");
            }

             maxAllowedLimit = GetMaximumAllowedLimit(employmentStatus, monthlyIncome);

            if (requestedLimit > maxAllowedLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(requestedLimit), $"Requested limit above the maximum allowed limit of {maxAllowedLimit}.");
            }

            _cardLimit = requestedLimit;
        }
    }
}
