using ProjectTimeApi.DTOs;
using ProjectTimeApi.Models;
using ProjectTimeApi.Repositories;

namespace ProjectTimeApi.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                Title = dto.Title,
            };

            await _repository.AddAsync(project);

            return new ProjectDto
            {
                Id = project.Id,
                Title = project.Title
            };
        }

        public async Task<ProjectDto?> UpdateAsync(int id, CreateProjectDto dto)
        {
            var project =  await _repository.GetByIdAsync(id);
            if (project == null) return null;

            project.Title = dto.Title;
            await _repository.UpdateAsync(project);

            return new ProjectDto
            {
                Id = project.Id,
                Title = project.Title
            };
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            var projects = await _repository.GetAllAsync();
            return projects.Select(u => new ProjectDto{
               Id = u.Id,
               Title = u.Title
            }).ToList();
        }

       public async Task<bool> RemoveAsync(int id)
       {
            var project =  await _repository.GetByIdAsync(id);
            if (project == null) return false;

            return await _repository.RemoveAsync(project);
       }

       public async Task<ProjectDto?> GetByIdAsync(int id)
       {
            var project = await _repository.GetByIdAsync(id);
            if(project == null) return null;

            return new ProjectDto
            {
                Id = project.Id,
                Title = project.Title
            };
       }
    }
}
