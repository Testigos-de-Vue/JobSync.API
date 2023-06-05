using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace JobSync.API.Recruitment.Resources;

public class SaveCandidateResource
{
    public string CvUrl { get; set; }
    public Boolean IsActive { get; set; }
    
    [Required]
    public JSType.Date PostulationDate { get; set; }

    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int JobAreaId { get; set; }
}