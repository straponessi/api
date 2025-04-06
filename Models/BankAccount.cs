using System.Text.Json.Serialization;

namespace api.Models
{
    public class BankAccount
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public long Balance { get; set; } = 0;

        public Player Player { get; set; } = null!;
        
        [JsonIgnore]
        public List<BankTransaсtion> BankTransaсtions { get; set; } = new();
    }
}
