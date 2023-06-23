using JobSync.API.Authentication.Domain.Repositories;
using JobSync.API.Authentication.Domain.Services;
using JobSync.API.Authentication.Domain.Services.Communication;
using JobSync.API.Authentication.Persistence.Repositories;

namespace JobSync.API.Authentication.Services;

public class AuthenticationService : IAuthenticationService
{
  private readonly IPasswordHashingService _passwordHashingService;
  private readonly IUserRepository _userRepository;

  public AuthenticationService(IPasswordHashingService passwordHashingService, IUserRepository userRepository)
  {
    _passwordHashingService = passwordHashingService;
    _userRepository = userRepository;
  }

  public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
  {
    var existingUser = await _userRepository.FindByEmailAsync(request.Email);

    if (existingUser == null)
      throw new Exception("No account was found associated with that email");

    var hashedPassword = _passwordHashingService.GetHash(request.Password);
    var isValidPassword = _passwordHashingService.VerifyPassword(existingUser.Password, hashedPassword);

    if (!isValidPassword)
      throw new Exception("Invalid email and password combination");

    var response = new AuthenticateResponse
    {
      Id = existingUser.Id,
      Email = existingUser.Email,
      Name = existingUser.Name,
      LastName = existingUser.LastName,
      ImageUrl = existingUser.ImageUrl,
      // TODO: Implement JWT
      Token = "JSON_WEB_TOKEN_PLACEHOLDER"
    };

    return response;
  }
}

