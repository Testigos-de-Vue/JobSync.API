using System.Runtime.InteropServices.JavaScript;

namespace JobSync.API.Recruitment.Resources;

public class PhaseResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public JSType.Date CreatedDate { get; set; }
    
    public ProcessResource Process { get; set; }
}