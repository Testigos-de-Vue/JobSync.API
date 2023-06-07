namespace JobSync.API.Profile.Domain.Models;

public class Role
{
  public int Id { get; set; }
  public string Name { get; set; }
  
  // Relationships
  public List<JobSync.API.Profile.Domain.Models.Profile> Profiles { get; set; }
}