namespace JobSync.API.Recruitment.Domain.Models;

public class JobArea
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<CandidateProfile> Candidates { get; set; }
}