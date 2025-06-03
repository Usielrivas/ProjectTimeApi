using ProjectTimeApi.DTOs;
using ProjectTimeApi.Models;
using ProjectTimeApi.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ProjectTimeApi.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
           if (await _repository.ExistsByEmailAsync(dto.Email))
               throw new Exception("Email already taken");

           var hash = new PasswordHasher<User>();

            var user = new User
            {
                Email = dto.Email,
                Active = dto.Active
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

        public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
        {
            var hash = new PasswordHasher<User>();
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;

            if (dto.Email is not null && dto.Email != user.Email && await _repository.ExistsByEmailAsync(dto.Email))
               throw new Exception("Email already taken");

            if (dto.Email is not null)
                user.Email = dto.Email;

            user.Active = dto.Active ?? user.Active;

            if (dto.Password is not null)
                user.PasswordDigest = hash.HashPassword(user, dto.Password);

            await _repository.UpdateAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Active = user.Active
            };
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return false;

            return await _repository.RemoveAsync(user);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                Active = u.Active
            }).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) { return null; }

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Active = user.Active
            };
        }
    }
}
