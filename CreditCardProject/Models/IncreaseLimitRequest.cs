// IncreaseLimitRequest.cs
namespace CreditCardProject.Models
{
    public class IncreaseLimitRequest
    {
        public decimal RequestedLimit { get; set; }
        public string EmploymentStatus { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal MaxAllowedLimit { get; set; }
    }
}
