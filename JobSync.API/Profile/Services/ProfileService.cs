using JobSync.API.Profile.Domain.Repositories;
using JobSync.API.Profile.Domain.Services;
using JobSync.API.Profile.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Profile.Services;

public class ProfileService : IProfileService
{
  private readonly IProfileRepository _profileRepository;
  private readonly IUnitOfWork _unitOfWork;

  public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
  {
    _profileRepository = profileRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<IEnumerable<Domain.Models.Profile>> ListAsync()
  {
    return await _profileRepository.ListAsync();
  }

  public async Task<ProfileResponse> SaveAsync(Domain.Models.Profile profile)
  {
    var existingProfile = await _profileRepository.FindByIdAsync(profile.Id);

    if (existingProfile != null)
      return new ProfileResponse("A profile already exists with that id");

    try
    {
      await _profileRepository.AddAsync(profile);
      await _unitOfWork.CompleteAsync();

      return new ProfileResponse(profile);
    }
    catch (Exception e)
    {
      return new ProfileResponse($"An error occurred while saving the profile: {e.Message}");
    }
  }

  public async Task<ProfileResponse> UpdateAsync(int profileId, Domain.Models.Profile profile)
  {
    var existingProfile = await _profileRepository.FindByIdAsync(profileId);

    if (existingProfile == null)
      return new ProfileResponse("Profile not found");

    if (existingProfile.UserId != profile.UserId)
      return new ProfileResponse("User id mismatch");

    existingProfile.CvUrl = profile.CvUrl;
    existingProfile.Role = profile.Role;
    existingProfile.OrganizationId = profile.OrganizationId;

    try
    {
      _profileRepository.Update(existingProfile);
      await _unitOfWork.CompleteAsync();

      return new ProfileResponse(existingProfile);
    }
    catch (Exception e)
    {
      return new ProfileResponse($"An error occurred while updating the profile: {e.Message}");
    }
  }

  public async Task<ProfileResponse> DeleteAsync(int profileId)
  {
    var existingProfile = await _profileRepository.FindByIdAsync(profileId);

    if (existingProfile == null)
      return new ProfileResponse("Profile not found");

    try
    {
      _profileRepository.Remove(existingProfile);
      await _unitOfWork.CompleteAsync();

      return new ProfileResponse(existingProfile);
    }
    catch (Exception e)
    {
      return new ProfileResponse($"An error occurred while deleting the profile: {e.Message}");
    }
  }
}