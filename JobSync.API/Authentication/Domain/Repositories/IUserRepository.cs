using JobSync.API.Authentication.Domain.Models;

namespace JobSync.API.Authentication.Domain.Repositories;

public interface IUserRepository
{
  Task<IEnumerable<User>> ListAsync();
  Task AddAsync(User user);
  Task<User> FindByIdAsync(int id);
  Task<User> FindByEmailAsync(string email);
  void Update(User user);
}
