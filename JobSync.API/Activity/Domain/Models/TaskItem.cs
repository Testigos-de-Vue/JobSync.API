using JobSync.API.Authentication.Domain.Models;

namespace JobSync.API.Activity.Domain.Models;

public class TaskItem
{
    public int Id { get; set}
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    
    //Relationships
    public int UserId { get; set; }
    public User User { get; set; }
}