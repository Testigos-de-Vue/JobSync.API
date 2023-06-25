using JobSync.API.Security.Resources;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Security.Domain.Services.Communication;

public class AuthenticateResponse
{

  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  public string ImageUrl { get; set; }
  public string PhoneNumber { get; set; }
  public string Country { get; set; }
  public string IsRecruiter { get; set; }
  public bool IsSubscribedToNewsletter { get; set; }
  public string Token { get; set; }
}

