using System.ComponentModel.DataAnnotations;

namespace MyGames.Data.Database.Models
{
    public class GameEntry
    {
        public int GameEntryID { get; set; }
        [Required]
        public int GameID { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public GameStatus Status { get; set; }
        public int? Rating { get; set; }
        public int? Progress { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
