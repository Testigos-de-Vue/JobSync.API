using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Resources;

namespace JobSync.API.Recruitment.Mapping;

public class ResourceToModelProfile: AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePhaseResource, Phase>();
        CreateMap<SaveProcessResource, Process>();
    }
}