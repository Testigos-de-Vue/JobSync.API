using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace JobSync.API.Recruitment.Resources;

public class SaveProcessResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(128)]
    public string Description { get; set; }
    
    [Required]
    public JSType.Date StartingDate { get; set; }
    
    [Required]
    public JSType.Date EndingDate { get; set; }
    
    public Boolean Status { get; set; }
}