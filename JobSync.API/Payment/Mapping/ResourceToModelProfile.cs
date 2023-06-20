﻿using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Resources;

namespace JobSync.API.Payment.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<PayResource, Pay>();
        CreateMap<PaymentPlanResource, PaymentPlan>();
    }
}