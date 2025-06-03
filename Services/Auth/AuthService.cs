using ProjectTimeApi.DTOs;
using ProjectTimeApi.Models;
using ProjectTimeApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectTimeApi.Services
{
    public class AuthService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<AuthOkDto?> VerifyLogin(LoginDto dto)
        {
            var user = await _repository.GetByEmailAsync(dto.Email);
            if (user == null) return null;

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordDigest, dto.Password);

            if (result != PasswordVerificationResult.Success) return null;

            var token = GenerateJwtToken(user);
            return new AuthOkDto
            {
                Key = token
            };
        }

        public async Task<UserDto> Register(RegisterDto dto)
        {
           if (await _repository.ExistsByEmailAsync(dto.Email))
               throw new Exception("Email already taken");

            var hash = new PasswordHasher<User>();

            var user = new User
            {
                Email = dto.Email,
                Active = false
            };

            user.PasswordDigest = hash.HashPassword(user, dto.Password);

            await _repository.AddAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Active = user.Active
            };
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
