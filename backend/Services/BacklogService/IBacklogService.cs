using MyGames.Data.DTO;

namespace MyGames.Services.BacklogService
{
    public interface IBacklogService
    {
        public Task AddGameEntryAsync(CreateGameEntryDto dto, int userId);
        public Task<List<UserGameListDto>> GetUserGamesAsync(int userId);
        public Task<bool> DeleteUserGameAsync(int id, int userId);
        public Task<bool> UpdateGameInfoAsync(UpdateGameEntryDto dto, int id, int userId);
    }
}
