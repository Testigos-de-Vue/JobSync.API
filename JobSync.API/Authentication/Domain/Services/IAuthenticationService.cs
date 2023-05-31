using JobSync.API.Authentication.Domain.Services.Communication;

namespace JobSync.API.Authentication.Domain.Services;

public interface IAuthenticationService
{
  Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
}
