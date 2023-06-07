using JobSync.API.Profile.Domain.Models;
using JobSync.API.Profile.Resources;

namespace JobSync.API.Profile.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
  public ResourceToModelProfile()
  {
    CreateMap<SaveRoleResource, Role>();
  }
}