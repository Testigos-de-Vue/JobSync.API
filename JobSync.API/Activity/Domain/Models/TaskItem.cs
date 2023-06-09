namespace JobSync.API.Activity.Domain.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Time { get; set; }
    public string Status { get; set; }

    //Relationships
    public int UserId { get; set; }
}
