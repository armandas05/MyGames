using Microsoft.EntityFrameworkCore;
using MyGames.Data.Database.Models;

namespace MyGames.Data.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<GameEntry> GameEntries { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        
    }
}
