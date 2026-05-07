using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyGames.Data.Database;
using MyGames.Data.Database.Models;
using MyGames.Data.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyGames.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _duration;
        public AuthService(IConfiguration config, AppDbContext context)
        {
            _context = context;

            _key = config["JwtSettings:Key"];
            _issuer = config["JwtSettings:Issuer"];
            _audience = config["JwtSettings:Audience"];
            _duration = config.GetValue<int>("JwtSettings:Duration");
        }
        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || user.Password != dto.Password) return null;

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_key)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
                new Claim("userId", user.UserID.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_duration),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
