using System.Runtime.InteropServices.JavaScript;

namespace JobSync.API.Recruitment.Domain.Models;

public class Recruitment
{
    public Recruitment()
    {
        Phases = new List<Phase>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public JSType.Date StartingDate { get; set; }
    public JSType.Date EndingDate { get; set; }
    public Boolean Status { get; set; }
    
    public List<Phase> Phases { get; set; }
}