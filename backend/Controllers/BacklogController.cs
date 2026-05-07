using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyGames.Data.DTO;
using MyGames.Services.BacklogService;

namespace MyGames.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BacklogController : Controller
    {
        private readonly IBacklogService _backlogService;

        public BacklogController(IBacklogService backlogService)
        {
            _backlogService = backlogService;
        }

        [HttpGet]
        public async Task<List<UserGameListDto>> GetUserGames()
        {
            var userId = int.Parse(User.FindFirst("userId")!.Value);

            var games = await _backlogService.GetUserGamesAsync(userId);

            return games;

        }
        [HttpPost]
        public async Task<IActionResult> AddGameEntry(CreateGameEntryDto dto)
        {
            if (dto == null) return BadRequest();

            var userId = int.Parse(User.FindFirst("userId")!.Value);

            await _backlogService.AddGameEntryAsync(dto, userId);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task DeleteUserGame(int id)
        {
            var userId = int.Parse(User.FindFirst("userId")!.Value);

            await _backlogService.DeleteUserGameAsync(id, userId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserGameInfo(UpdateGameEntryDto dto, int id)
        {
            if (dto == null) return BadRequest();

            var userId = int.Parse(User.FindFirst("userId")!.Value);

            await _backlogService.UpdateGameInfoAsync(dto, id, userId);

            return Ok();
        }

    }
}
