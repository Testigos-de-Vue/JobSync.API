namespace JobSync.API.Profile.Resources;

public class ProfileResource
{
  public int Id;
  public string CvUrl;
  public RoleResource Role { get; set; }
  public int OrganizationId { get; set; }
  public int UserId { get; set; }
}