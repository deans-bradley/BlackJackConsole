using System.Text.Json;
using System.Text.Json.Serialization;
using BlackJackConsole.Models;

namespace BlackJackConsole
{
    public class Game
    {
        private List<PlayingCard> playingCards = [];
        private List<PlayingCard> playerHand = [];
        private List<PlayingCard> dealerHand = [];
        private int playerCash = 100;

        public void Start()
        {
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("Press any key to start.");
            Console.ReadLine();

            PlayRound();
        }

        private void PlayRound()
        {
            playingCards = ShuffleDeck();
            DealCards();
            Console.ReadLine();
        }

        private void DealCards()
        {
            playerHand.Add(DealCard());
            dealerHand.Add(DealCard());
            playerHand.Add(DealCard());
            dealerHand.Add(DealCard());

            Console.WriteLine("Player hand:");
            foreach (PlayingCard card in playerHand)
            {
                Console.WriteLine(card.Value + " of " + card.Suit);
            }

            Console.WriteLine("Dealer hand:");
            Console.WriteLine(dealerHand[0].Value + " of " + dealerHand[0].Suit);
            Console.WriteLine("Hidden card");
        }

        private PlayingCard DealCard()
        {
            PlayingCard card = playingCards[0];
            playingCards.RemoveAt(0);
            return card;
        }

        private List<PlayingCard> ShuffleDeck()
        {
            List<PlayingCard> playingCards = GetPlayingCards();
            Random random = new();
            List<PlayingCard> shuffledDeck = playingCards.OrderBy(x => random.Next()).ToList();

            return shuffledDeck;
        } 
        
        private List<PlayingCard> GetPlayingCards() 
        {
            string baseDirectory = GetProjectBaseDirectory();
            string jsonFile = Path.Combine(baseDirectory, "Data", "PlayingCards.json");
            string json = File.ReadAllText(jsonFile);

            Root root = JsonSerializer.Deserialize<Root>(json) ?? throw new Exception("Playing cards not found.");
            List<PlayingCard> playingCards = root.PlayingCards;

            return playingCards;
        }

        private string GetProjectBaseDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo? directory = new(currentDir);

            while (directory != null && directory.Exists)
            {
                if (Directory.GetFiles(directory.FullName, "*.csproj").Length > 0)
                {
                    return directory.FullName;
                }
                directory = directory.Parent;
            }

            throw new Exception("Project root directory not found.");
        }
    }
}