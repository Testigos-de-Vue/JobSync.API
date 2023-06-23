using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Security.Domain.Services.Communication;

public class UpdateRequest
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
  public string PhoneNumber { get; set; }
  public bool IsSubscribedToNewsletter { get; set; }
  public bool isRecruiter { get; set; }
}