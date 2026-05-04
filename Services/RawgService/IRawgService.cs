using MyGames.Data.DTO;

namespace MyGames.Services.RawgService
{
    public interface IRawgService
    {
        public Task<List<GameDto>> SearchGamesAsync(string query);
    }
}
