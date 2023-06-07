using JobSync.API.Profile.Domain.Services.Communication;

namespace JobSync.API.Profile.Domain.Services;

public interface IProfileService
{
  Task<IEnumerable<Models.Profile>> ListAsync();
  Task<ProfileResponse> SaveAsync(Models.Profile role);
  Task<ProfileResponse> UpdateAsync(int roleId, Models.Profile role);
  Task<ProfileResponse> DeleteAsync(int roleId);
} 