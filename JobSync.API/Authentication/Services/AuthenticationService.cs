using JobSync.API.Authentication.Domain.Services;
using JobSync.API.Authentication.Domain.Services.Communication;
using JobSync.API.Authentication.Persistence.Repositories;
using JobSync.API.Authentication.Resources;

namespace JobSync.API.Authentication.Services;

public class AuthenticationService : IAuthenticationService
{
  private readonly PasswordHashingService _passwordHashingService;
  private readonly UserRepository _userRepository;

  public AuthenticationService(PasswordHashingService passwordHashingService, UserRepository userRepository)
  {
    _passwordHashingService = passwordHashingService;
    _userRepository = userRepository;
  }

  public async Task<UserResponse> Authenticate(AuthenticateRequest request)
  {
    var existingUser = await _userRepository.FindByEmailAsync(request.Email);

    if (existingUser == null)
      return new UserResponse("No account was found associated with that email");

    string hashedPassword = _passwordHashingService.GetHash(request.Password);
    bool isValidPassword = _passwordHashingService.VerifyPassword(existingUser.Password, hashedPassword);

    if (!isValidPassword)
      return new UserResponse("Invalid email and password combination");
    
    return new UserResponse(existingUser);
  }
}
