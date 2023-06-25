using JobSync.API.Profile.Resources;

namespace JobSync.API.Organization.Resources;

public class OrganizationResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string LogoUrl { get; set; }
    public string Address { get; set; }
    
    
    public PlanResource Plan { get; set; }
    
    public int PlanId { get; set; }
    public List<int> ProfilesId { get; set; }
}