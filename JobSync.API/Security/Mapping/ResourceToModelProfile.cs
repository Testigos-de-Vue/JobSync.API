using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Domain.Services.Communication;
using JobSync.API.Security.Resources;

namespace JobSync.API.Security.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
  public ResourceToModelProfile()
  {
    CreateMap<RegisterRequest, User>();
    CreateMap<UpdateRequest, User>().ForAllMembers(options => options.Condition((source, target, property) => {
        if (property == null) return false;
        return property.GetType() != typeof(string) || !string.IsNullOrEmpty((string)property);
      })
    );
  }
}
