using JobSync.API.Profile.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Profile.Domain.Services.Communication;

public class RoleResponse : BaseResponse<Role>
{
  public RoleResponse(string message) : base(message)
  {
    
  }

  public RoleResponse(Role resource) : base(resource)
  {
    
  }
}