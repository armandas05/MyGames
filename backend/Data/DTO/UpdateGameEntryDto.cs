using MyGames.Data.Database.Models;

namespace MyGames.Data.DTO
{
    public class UpdateGameEntryDto
    {
        public GameStatus Status { get; set; }
        public int? Rating { get; set; }
        public int? Progress { get; set; }
        public string? Notes { get; set; }
    }
}
