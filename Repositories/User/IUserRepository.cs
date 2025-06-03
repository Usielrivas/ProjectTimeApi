using ProjectTimeApi.Models;
using System.Collections.Generic;
// using System.Threading.Tasks;

namespace ProjectTimeApi.Repositories
{
  public interface IUserRepository
  {
      Task AddAsync(User user);
      Task UpdateAsync(User user);
      Task<List<User>> GetAllAsync();
      Task<User?> GetByIdAsync(int id);
      Task<bool> RemoveAsync(User user);
      Task<bool> ExistsByEmailAsync(string email);
  }
}

