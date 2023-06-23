using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Authentication.Domain.Services.Communication;

public class RegisterRequest
{
  [Required] public string Name { get; set; }
  [Required] public string LastName { get; set; }
  [Required] public string Email { get; set; }
  [Required] public string PhoneNumber { get; set; }
  [Required] public bool IsSubscribedToNewsletter { get; set; }
}
