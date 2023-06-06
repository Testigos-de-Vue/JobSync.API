namespace JobSync.API.Recruitment.Domain.Models;

public class Process
{
    public Process()
    {
        Phases = new List<Phase>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public Boolean Status { get; set; }
    
    public List<Phase> Phases { get; set; }
}