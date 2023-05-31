using JobSync.API.Authentication.Domain.Services.Communication;
using JobSync.API.Authentication.Resources;

namespace JobSync.API.Authentication.Domain.Services;

public interface IAuthenticationService
{
  Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
}
