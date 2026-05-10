using Microsoft.EntityFrameworkCore;
using MyGames.Data.Database;
using MyGames.Data.Database.Models;
using MyGames.Data.DTO;

namespace MyGames.Services.BacklogService
{
    public class BacklogService : IBacklogService
    {
        private readonly AppDbContext _context;
        public BacklogService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserGameListDto>> GetUserGamesAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            var gamesList = await _context.GameEntries
                .Where(g => g.UserID == user.UserID)
                .Select(g => new UserGameListDto
                {
                    GameEntryID = g.GameEntryID,
                    GameID = g.GameID,
                    GameName = g.GameName,
                    Status = g.Status,
                    Rating = g.Rating,
                    Progress = g.Progress,
                    Notes = g.Notes,
                    BackgroundImage = g.BackgroundImage,
                })
                .ToListAsync();

            return gamesList;
        }
        public async Task<bool> DeleteUserGameAsync(int id, int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            var game = await _context.GameEntries
                .FirstOrDefaultAsync(g => g.GameEntryID == id && g.UserID == user.UserID);

            if (game == null) return false;

            _context.GameEntries.Remove(game);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task AddGameEntryAsync(CreateGameEntryDto dto, int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var gameEntry = new GameEntry
            {
                GameID = dto.GameID,
                GameName = dto.GameName,
                Status = GameStatus.PlanToPlay,
                CreatedAt = DateTime.UtcNow,
                UserID = user.UserID,
                BackgroundImage = dto.BackgroundImage
            };

            await _context.GameEntries.AddAsync(gameEntry);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateGameInfoAsync(UpdateGameEntryDto dto, int id, int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            var game = await _context.GameEntries
                .FirstOrDefaultAsync(g => g.GameEntryID == id && g.UserID == user.UserID);

            if (game == null) return false;

            game.Status = dto.Status;
            game.Rating = dto.Rating;
            game.Progress = dto.Progress;
            game.Notes = dto.Notes;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
