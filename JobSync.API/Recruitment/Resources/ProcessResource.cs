using System.Runtime.InteropServices.JavaScript;

namespace JobSync.API.Recruitment.Resources;

public class ProcessResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public JSType.Date StartingDate { get; set; }
    public JSType.Date EndingDate { get; set; }
    public Boolean Status { get; set; }
}