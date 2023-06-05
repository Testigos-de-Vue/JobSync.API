using AutoMapper;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Resources;

namespace JobSync.API.Recruitment.Mapping;

public class ResourceToModelProfile: Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveJobAreaResource, JobArea>();
        CreateMap<SaveCandidateResource, Candidate>();
        CreateMap<SavePhaseResource, Phase>();
        CreateMap<SaveProcessResource, Process>();
    }
}