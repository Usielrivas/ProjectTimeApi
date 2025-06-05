using ProjectTimeApi.Models;

namespace ProjectTimeApi.Repositories
{
  public interface IProjectRepository
  {
      Task AddAsync(Project project);
      Task UpdateAsync(Project project);
      Task<List<Project>> GetAllAsync();
      Task<Project?> GetByIdAsync(int id);
      Task<bool> RemoveAsync(Project project);
  }
}

