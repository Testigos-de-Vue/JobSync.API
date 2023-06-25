using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace JobSync.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
  [Required] public string FirstName { get; set; }
  [Required] public string LastName { get; set; }
  [Required] public string Email { get; set; }
  [Required] public string Country{ get; set; }
  public string ImageUrl { get; set; } = "https://cdn-icons-png.flaticon.com/512/3237/3237472.png";
  [Required] public string Password { get; set; }
  [Required] public string PhoneNumber { get; set; }
  [Required] public bool IsSubscribedToNewsletter { get; set; }
  [Required] public bool IsRecruiter { get; set; }
}
