using JobSync.API.Security.Resources;

namespace JobSync.API.Activity.Resources;

public class TaskResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Time { get; set; }
    public string Status { get; set; }
    
    public int UserId { get; set; }
}
