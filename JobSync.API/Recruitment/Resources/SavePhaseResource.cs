using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Recruitment.Resources;

public class SavePhaseResource
{
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
    
    [MaxLength(256)]
    public string Description { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    public int ProcessId { get; set; }
}