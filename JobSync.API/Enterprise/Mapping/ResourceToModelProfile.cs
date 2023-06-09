using JobSync.API.Organization.Resources;

namespace JobSync.API.Organization.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<OrganizationResource, Domain.Models.Organization>();
        CreateMap<PlanResource, Domain.Models.Plan>();        
    }
    
    
    
}