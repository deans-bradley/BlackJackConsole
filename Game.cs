using System.Text.Json;
using System.Text.Json.Serialization;
using BlackJackConsole.Models;

namespace BlackJackConsole
{
    public class Game
    {
        private List<PlayingCards> GetPlayingCards() 
        {
            File.ReadAllLines("");

            return [];
        }

        private string GetProjectBaseDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo? directory = new DirectoryInfo(currentDir);

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