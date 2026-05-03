using MyGames.Data.DTO;
using System.Text.Json;

namespace MyGames.Services.RawgService
{
    public class RawgService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "api key :)";

        public RawgService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GameDto>> SearchGames(string query)
        {
            var url = $"https://api.rawg.io/api/games?key={_apiKey}&search={query}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return new List<GameDto>();

            var json = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);
            var results = doc.RootElement.GetProperty("results");

            var games = new List<GameDto>();

            foreach (var game in results.EnumerateArray())
            {
                games.Add(new GameDto
                {
                    Id = game.GetProperty("id").GetInt32(),
                    Name = game.GetProperty("name").GetString(),
                    Released = game.TryGetProperty("released", out var rel) ? rel.GetString() : null,
                    BackgroundImage = game.TryGetProperty("background_image", out var img) ? img.GetString() : null,
                    Rating = game.TryGetProperty("rating", out var rating) ? rating.GetDouble() : 0
                });
            }

            return games;
        }

    }
}
