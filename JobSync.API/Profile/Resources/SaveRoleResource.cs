using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Profile.Resources;

public class SaveRoleResource
{
  [Required]
  public string Name { get; set; }
}