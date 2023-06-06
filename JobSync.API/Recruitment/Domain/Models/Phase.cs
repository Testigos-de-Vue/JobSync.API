namespace JobSync.API.Recruitment.Domain.Models;

public class Phase
{
    public Phase()
    {
        CandidateProfiles = new List<CandidateProfile>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public int ProcessId { get; set; }
    public Process Process { get; set; }
    
    public List<CandidateProfile> CandidateProfiles { get; set; }
}