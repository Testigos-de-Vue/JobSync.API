using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Domain.Services.Communication;

namespace JobSync.API.Security.Domain.Services;

public interface IUserService
{
  Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);
  Task<IEnumerable<User>> ListAsync();
  Task<User> GetByIdAsync(int id);
  Task RegisterAsync(RegisterRequest mode);
  Task UpdateAsync(int id, UpdateRequest model);
  Task DeleteAsync(int id);
}