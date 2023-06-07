using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Resources;

namespace JobSync.API.Recruitment.Mapping;

public class ResourceToModelProfile: AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveJobAreaResource, JobArea>();
        CreateMap<SaveCandidateProfileResource, CandidateProfile>();
        CreateMap<SaveRecruitmentPhaseResource, RecruitmentPhase>();
        CreateMap<SaveRecruitmentProcessResource, RecruitmentProcess>();
    }
}