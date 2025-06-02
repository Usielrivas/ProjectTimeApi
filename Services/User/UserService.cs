using ProjectTimeApi.DTOs;
using ProjectTimeApi.Models;
using ProjectTimeApi.Repositories;

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
            var user = new User
            {
                Name = dto.Name,
            };

            await _repository.AddAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
        
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name
            }).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) { return null; }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
