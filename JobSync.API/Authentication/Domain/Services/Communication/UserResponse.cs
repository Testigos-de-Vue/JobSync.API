using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Authentication.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
  public UserResponse(string message) : base(message)
  {
  }

  public UserResponse(User resource) : base(resource)
  {
  }
}
