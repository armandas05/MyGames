using MyGames.Data.Database.Models;

namespace MyGames.Data.DTO
{
    public class UserGameListDto
    {
        public int GameEntryID { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; }
        public GameStatus Status { get; set; }
        public int? Rating { get; set; }
        public int? Progress { get; set; }
        public string? Notes { get; set; }
        public string? BackgroundImage { get; set; }
    }
}
