using Microsoft.AspNetCore.Mvc;
using MyGames.Data.DTO;
using MyGames.Services.BacklogService;

namespace MyGames.Controllers
{
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
            var games = await _backlogService.GetUserGamesAsync();

            return games;
            
        }

        [HttpDelete]
        public async Task DeleteUserGame(int id)
        {
            await _backlogService.DeleteUserGameAsync(id);
        }


        [HttpPost]
        public async Task<IActionResult> AddGameEntry(CreateGameEntryDto dto)
        {
            if (dto == null) return BadRequest();

            await _backlogService.AddGameEntryAsync(dto);

            return Ok();
        }
    }
}
