using System.Text.Json.Serialization;
using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Authentication.Domain.Models;

public class User
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  public string ImageUrl { get; set; }
  public string PhoneNumber { get; set; }
  public bool IsSubscribedToNewsletter { get; set; }
  
  public List<CandidateProfile> CandidateProfiles { get; set; }
  
  [JsonIgnore]
  public string Password { get; set; }
}
