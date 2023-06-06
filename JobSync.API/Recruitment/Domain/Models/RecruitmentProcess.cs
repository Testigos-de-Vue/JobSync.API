namespace JobSync.API.Recruitment.Domain.Models;

public class RecruitmentProcess
{
    public RecruitmentProcess()
    {
        Phases = new List<RecruitmentPhase>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public Boolean Status { get; set; }
    
    public List<RecruitmentPhase> Phases { get; set; }
}