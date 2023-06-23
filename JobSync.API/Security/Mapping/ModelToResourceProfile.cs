using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Resources;

namespace JobSync.API.Security.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
  public ModelToResourceProfile()
  {
    CreateMap<User, UserResource>();
  }
}
