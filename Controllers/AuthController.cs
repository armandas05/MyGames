using Microsoft.AspNetCore.Mvc;
using MyGames.Data.DTO;
using MyGames.Services.AuthService;

namespace MyGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (dto == null) return BadRequest();

            var token = await _authService.LoginAsync(dto);

            if (token == null) return Unauthorized();

            return Ok(new { token });
        }
    }
}
