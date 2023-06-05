using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Recruitment.Resources;

public class SaveJobAreaResource
{
    [Required]
    public string Name { get; set; }
}