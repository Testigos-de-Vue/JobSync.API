using JobSync.API.Profile.Domain.Models;

namespace JobSync.API.Profile.Domain.Repositories;

public interface IRoleRepository
{
  Task<IEnumerable<Role>> ListAsync();
  Task AddAsync(Role role);
  Task<Role> FindByIdAsync(int id);
  Task<Role> FindByNameAsync(string name);
  void Update(Role role);
  void Remove(Role role);
}