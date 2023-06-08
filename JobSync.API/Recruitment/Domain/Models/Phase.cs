using System.ComponentModel.DataAnnotations.Schema;

namespace JobSync.API.Recruitment.Domain.Models;

public class Phase
{
    public Phase()
    {
        ProfileIds = new List<int>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public int RecruitmentProcessId { get; set; }
    public Process Process { get; set; }
    
    // Candidate profiles
    [NotMapped]
    public List<int> ProfileIds { get; set; }
}