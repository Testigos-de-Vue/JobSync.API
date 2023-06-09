﻿using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Domain.Services.Communication;
using JobSync.API.Security.Resources;

namespace JobSync.API.Security.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
  public ModelToResourceProfile()
  {
    CreateMap<User, AuthenticateResponse>();
    CreateMap<User, UserResource>();
  }
}
