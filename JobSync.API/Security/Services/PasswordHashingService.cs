using JobSync.API.Authentication.Domain.Services;

namespace JobSync.API.Authentication.Services;

public class PasswordHashingService : IPasswordHashingService
{
  public string GetHash(string password)
  {
    return BCrypt.Net.BCrypt.HashPassword(password);
  }

  public bool VerifyPassword(string password, string hashedPassword)
  {
    return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
  }
}
