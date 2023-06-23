namespace JobSync.API.Security.Domain.Services;

public interface IPasswordHashingService
{
    string GetHash(string password);
    bool VerifyPassword(string password, string hashedPassword);
}