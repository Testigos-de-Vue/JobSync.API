using JobSync.API.Profile.Domain.Models;
using JobSync.API.Profile.Domain.Services.Communication;

namespace JobSync.API.Profile.Domain.Services;

public interface IRoleService
{
  Task<IEnumerable<Role>> ListAsync();
  Task<RoleResponse> SaveAsync(Role role);
  Task<RoleResponse> UpdateAsync(int roleId, Role role);
  Task<RoleResponse> DeleteAsync(int roleId);
}