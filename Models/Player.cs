using System.Text.Json.Serialization;

namespace api.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public BankAccount? BankAccount { get; set; }
    }
}
