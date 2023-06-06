using System.ComponentModel.DataAnnotations;

namespace JobSync.API.Recruitment.Resources;

public class SaveCandidateProfileResource
{
    [MaxLength(256)]
    public string CvUrl { get; set; }
    
    public Boolean IsActive { get; set; }
    
    [Required]
    public DateTime PostulationDate { get; set; }

    [Required]
    public int PhaseId { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int JobAreaId { get; set; }
}