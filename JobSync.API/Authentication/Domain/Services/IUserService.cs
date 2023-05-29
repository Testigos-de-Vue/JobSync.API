using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Authentication.Domain.Services.Communication;

namespace JobSync.API.Authentication.Domain.Services;

public interface IUserService
{
  Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
  Task<IEnumerable<User>> ListAsync();
  Task<UserResponse> CreateAsync(RegisterRequest request);
  Task<UserResponse> UpdateAsync(int id, User user);
  Task<UserResponse> DeleteAsync(int id);
}
