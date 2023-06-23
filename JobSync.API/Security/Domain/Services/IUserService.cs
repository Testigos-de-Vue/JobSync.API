using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Authentication.Domain.Services.Communication;

namespace JobSync.API.Authentication.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> CreateAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
}