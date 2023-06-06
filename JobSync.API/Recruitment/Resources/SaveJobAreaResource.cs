using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Recruitment.Resources;

public class SaveJobAreaResource
{
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
}