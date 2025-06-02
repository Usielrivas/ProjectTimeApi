using ProjectTimeApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTimeApi.Repositories
{
  public interface IUserRepository
  {
      Task AddAsync(User user);
      Task<List<User>> GetAllAsync();
      Task<User?> GetByIdAsync(int id);
  }
}

