using System.Text.Json.Serialization;

namespace BlackJackConsole.Models
{
    public class PlayingCards
    {
        [JsonPropertyName("suit")]
        public string Suit { get; set; } = String.Empty;
        [JsonPropertyName("value")]
        public string Value { get; set; } = String.Empty;
    }
}