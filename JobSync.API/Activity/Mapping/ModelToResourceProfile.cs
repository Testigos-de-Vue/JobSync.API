using JobSync.API.Activity.Resources;
using JobSync.API.Activity.Domain.Models;

namespace JobSync.API.Activity.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<TaskItem, TaskResource>();
    }
}
