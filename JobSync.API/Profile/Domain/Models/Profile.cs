namespace JobSync.API.Profile.Domain.Models;

public class Profile
{
  public int Id { get; set; }
  public string CvUrl { get; set; }
  
  // Relationships
  public Role Role { get; set; }
  public int OrganizationId { get; set; }
  public int UserId { get; set; }
}