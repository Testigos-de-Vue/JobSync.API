using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace JobSync.API.Recruitment.Resources;

public class SavePhaseResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(128)]
    public string Description { get; set; }
    
    [Required]
    public JSType.Date CreatedDate { get; set; }
    
    [Required]
    public int ProcessId { get; set; }
}