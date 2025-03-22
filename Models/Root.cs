using System.Text.Json.Serialization;

namespace BlackJackConsole.Models
{
    public class Root
    {
        [JsonPropertyName("playingCards")]
        public List<PlayingCard> PlayingCards { get; set; } = [];
    }
}