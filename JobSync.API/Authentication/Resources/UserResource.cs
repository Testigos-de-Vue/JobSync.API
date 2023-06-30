namespace JobSync.API.Authentication.Resources;

public class UserResource
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  public string ImageUrl { get; set; }
  public bool IsRecruiter { get; set; }
}
