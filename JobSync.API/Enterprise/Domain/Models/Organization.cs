using System.ComponentModel.DataAnnotations.Schema;

namespace JobSync.API.Organization.Domain.Models;

public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string LogoUrl { get; set; }
    public string Address { get; set; }
    
    // Relationships
    public int OrganizationPlanId { get; set; }
    public Plan OrganizationPlan { get; set; }
    
    [NotMapped]
    public List<int> ProfileIds { get; set; } 
}