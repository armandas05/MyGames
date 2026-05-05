using MyGames.Data.DTO;

namespace MyGames.Services.AuthService
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDto dto);
    }
}
