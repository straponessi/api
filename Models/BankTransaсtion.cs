using System.Text.Json.Serialization;

namespace api.Models
{
    public class BankTransaсtion
    {
        public long Id { get; set; }
        public long BankAccountId { get; set; }
        public long Amount { get; set; }
        public string Source { get; set; } = "Unknown";
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public BankAccount BankAccount { get; set; } = null!;
    }
}
