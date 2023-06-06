﻿using AutoMapper;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Resources;

namespace JobSync.API.Recruitment.Mapping;

public class ModelToResourceProfile: Profile
{
    protected ModelToResourceProfile()
    {
        CreateMap<JobArea, JobAreaResource>();
        CreateMap<CandidateProfile, CandidateProfileResource>();
        CreateMap<Phase, PhaseResource>();
        CreateMap<Process, ProcessResource>();
    }
}