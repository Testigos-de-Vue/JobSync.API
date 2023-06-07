using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Profile.Resources;

public class SaveProfileResource
{
  [MaxLength(255)]
  public string CvUrl;
  
  [Required]
  public int RoleId { get; set; }
  
  public int OrganizationId { get; set; }
  
  [Required]
  public int UserId { get; set; }
}