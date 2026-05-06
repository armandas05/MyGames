using Microsoft.AspNetCore.Mvc;
using MyGames.Services.RawgService;

namespace MyGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly RawgService _rawgService;

        public GamesController(RawgService rawgService)
        {
            _rawgService = rawgService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            var games = await _rawgService.SearchGamesAsync(query);
            return Ok(games);
        }
    }
}
