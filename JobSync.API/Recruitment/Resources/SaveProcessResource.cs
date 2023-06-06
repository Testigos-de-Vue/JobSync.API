using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Recruitment.Resources;

public class SaveProcessResource
{
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
    
    [MaxLength(256)]
    public string Description { get; set; }
    
    [Required]
    public DateTime StartingDate { get; set; }
    
    [Required]
    public DateTime EndingDate { get; set; }
    
    public Boolean Status { get; set; }
}