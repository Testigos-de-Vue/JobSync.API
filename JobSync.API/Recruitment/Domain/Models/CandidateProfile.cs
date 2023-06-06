using JobSync.API.Authentication.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Models;

public class CandidateProfile
{
    public int Id { get; set; }
    public string CvUrl { get; set; }
    public Boolean IsActive { get; set; }
    public DateTime PostulationDate { get; set; }
    
    
    public int JobAreaId { get; set; }
    public JobArea JobArea { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }

    public int PhaseId { get; set; }
    public RecruitmentPhase RecruitmentPhase { get; set; }
}