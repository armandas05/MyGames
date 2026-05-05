using System.ComponentModel.DataAnnotations;

namespace MyGames.Data.Database.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoggedIn { get; set; }

        // rysiai
        public List<GameEntry> GameEntries { get; set; } = new(); 

    }
}
