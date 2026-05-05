using MyGames.Data.DTO;

namespace MyGames.Services.BacklogService
{
    public interface IBacklogService
    {
        public Task AddGameEntryAsync(CreateGameEntryDto dto);
        public Task<List<UserGameListDto>> GetUserGamesAsync();
        public Task<bool> DeleteUserGameAsync(int id);
        public Task<bool> UpdateGameInfoAsync(UpdateGameEntryDto dto, int id);
    }
}
