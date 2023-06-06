namespace JobSync.API.Recruitment.Domain.Models;

public class RecruitmentPhase
{
    public RecruitmentPhase()
    {
        CandidateProfiles = new List<CandidateProfile>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public int RecruitmentProcessId { get; set; }
    public RecruitmentProcess RecruitmentProcess { get; set; }
    
    public List<CandidateProfile> CandidateProfiles { get; set; }
}