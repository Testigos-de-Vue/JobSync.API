using JobSync.API.Profile.Domain.Services.Communication;

namespace JobSync.API.Profile.Domain.Services;

public interface IProfileService
{
  Task<IEnumerable<Models.Profile>> ListAsync();
  Task<ProfileResponse> SaveAsync(Models.Profile profile);
  Task<ProfileResponse> UpdateAsync(int profileId, Models.Profile profile);
  Task<ProfileResponse> DeleteAsync(int profileId);
} 