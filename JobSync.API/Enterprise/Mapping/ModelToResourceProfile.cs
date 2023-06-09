using JobSync.API.Organization.Domain.Services.Communication;
using JobSync.API.Organization.Resources;

namespace JobSync.API.Organization.Mapping;

public class ModelToResourceProfile: AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Organization, OrganizationResource>();
        CreateMap<Domain.Models.Plan, PlanResource>();
    }
}

