using Microsoft.EntityFrameworkCore;

namespace MyGames.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        
    }
}
