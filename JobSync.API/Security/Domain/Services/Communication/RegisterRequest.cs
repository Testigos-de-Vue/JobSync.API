using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
  [Required] public string FirstName { get; set; }
  [Required] public string LastName { get; set; }
  [Required] public string Email { get; set; }
  [Required] public string Password { get; set; }
  [Required] public string PhoneNumber { get; set; }
  [Required] public bool IsSubscribedToNewsletter { get; set; }
  [Required] public bool isRecruiter { get; set; }
}
