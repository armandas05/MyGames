using MyGames.Data.Database.Models;

namespace MyGames.Data.DTO
{
    public class UserGameListDto
    {
        public int GameID { get; set; }
        public string GameName { get; set; }
        public GameStatus Status { get; set; }
        public int? Rating { get; set; }
        public int? Progress { get; set; }
        public string? Notes { get; set; }
    }
}
