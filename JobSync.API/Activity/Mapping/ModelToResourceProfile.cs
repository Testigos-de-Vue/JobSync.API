using AutoMapper;
using JobSync.API.Activity.Resources;
using JobSync.API.Activity.Domain.Models;

namespace JobSync.API.Activity.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<TaskItem, TaskResource>();
    }
}
