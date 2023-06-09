

using JobSync.API.Organization.Domain.Models;

public class PlanResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Organization> Organizations { get; set; }
}