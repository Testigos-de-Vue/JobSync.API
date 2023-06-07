using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Authentication.Resources;

namespace JobSync.API.Authentication.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
  public ModelToResourceProfile()
  {
    CreateMap<User, UserResource>();
  }
}
