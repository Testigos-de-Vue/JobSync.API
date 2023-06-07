using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Profile.Domain.Services.Communication;

public class ProfileResponse : BaseResponse<Models.Profile>
{
  public ProfileResponse(string message) : base(message)
  {
  }

  public ProfileResponse(Models.Profile resource) : base(resource)
  {
  }
}