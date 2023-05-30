using JobSync.API.Authentication.Resources;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Authentication.Domain.Services.Communication;

public class AuthenticateResponse : BaseResponse<UserResource>
{
  public AuthenticateResponse(string message) : base(message)
  {
  }

  public AuthenticateResponse(UserResource resource) : base(resource)
  {
  }
}
