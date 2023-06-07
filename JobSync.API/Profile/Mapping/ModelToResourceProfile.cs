using JobSync.API.Profile.Domain.Models;
using JobSync.API.Profile.Resources;

namespace JobSync.API.Profile.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
  public ModelToResourceProfile()
  {
    CreateMap<Role, RoleResource>();
  }
}