using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Domain.Services.Communication;

namespace JobSync.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> CreateAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
}