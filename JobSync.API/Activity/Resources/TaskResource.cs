using JobSync.API.Authentication.Resources;

namespace JobSync.API.Activity.Resources;

public class TaskResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    
    public UserResource User { get; set; }
}
