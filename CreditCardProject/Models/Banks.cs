using CreditCardProject.MockData;
using Microsoft.Extensions.Caching.Memory;

namespace CreditCardProject.Models
{
    public class Banks
    {
        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private const string CacheKey = "Banks";

        public string Name { get; set; }
        public string Description { get; set; }
        public int BankCode { get; set; }

        public Banks(string name, string description, int bankcode)
        {
            Name = name;
            Description = description;
            BankCode = bankcode;
        }

        public static List<Banks> GetBanks()
        {
            // Check if the list of banks is cached
            if (!_cache.TryGetValue<List<Banks>>(CacheKey, out var banks))
            {
                // If not cached, retrieve the list of banks from the mock data
                banks = BanksData.Banks;

                // Cache the list of banks for 7 minutes
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(7));

                _cache.Set(CacheKey, banks, cacheOptions);
            }

            return banks;
        }
    }
}
