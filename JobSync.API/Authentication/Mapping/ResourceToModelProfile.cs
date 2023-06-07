using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Authentication.Resources;

namespace JobSync.API.Authentication.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
  public ResourceToModelProfile()
  {
    CreateMap<UserResource, User>();
  }
}
