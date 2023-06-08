using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Resources;

namespace JobSync.API.Recruitment.Mapping;

public class ModelToResourceProfile: AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Phase, PhaseResource>();
        CreateMap<Process, ProcessResource>();
    }
}