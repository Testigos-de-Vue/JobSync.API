using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Resources;

namespace JobSync.API.Security.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
  public ResourceToModelProfile()
  {
    CreateMap<UserResource, User>();
  }
}
