using System.Runtime.InteropServices.JavaScript;

namespace JobSync.API.Recruitment.Domain.Models;

public class Phase
{
    public Phase()
    {
        Candidates = new List<Candidate>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public JSType.Date CreatedDate { get; set; }
    
    public int RecruitmentId { get; set; }
    public Process Process { get; set; }
    
    public List<Candidate> Candidates { get; set; }
}