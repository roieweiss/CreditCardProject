using CreditCardProject.Models;

namespace CreditCardProject.MockData
{
    public static class BanksData
    {
        public static readonly List<Banks> Banks = new List<Banks>
        {
          new Banks("Bank Hapoalim", "Largest bank in Israel", 12),
            new Banks("Bank Leumi", "Second largest bank in Israel", 10),
            new Banks("Bank Mizrahi-Tefahot", "One of the largest banks in Israel", 20),
            new Banks("Bank Discount", "Retail bank in Israel", 11),
            new Banks("Israel Discount Bank", "International banking group", 15),
            new Banks("Bank Otsar Ha-Hayal", "Bank specializing in services to soldiers", 17),
            new Banks("Bank Mercantile Discount", "Commercial bank in Israel", 19),
            new Banks("Bank Massad", "Subsidiary of Bank Leumi", 21),
            new Banks("Union Bank of Israel", "Universal bank in Israel", 14)

        };
    }
}
