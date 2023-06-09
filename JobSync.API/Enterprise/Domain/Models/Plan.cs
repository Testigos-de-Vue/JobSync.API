namespace JobSync.API.Organization.Domain.Models;

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Organization> Organizations { get; set; }
}