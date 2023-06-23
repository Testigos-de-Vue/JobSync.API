using JobSync.API.Security.Domain.Services.Communication;

namespace JobSync.API.Security.Domain.Services;

public interface IAuthenticationService
{

  Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
}

