using AutoMapper;
using JobSync.API.Activity.Resources;
using JobSync.API.Activity.Domain.Models;

namespace JobSync.API.Activity.Mapping;

public class ResourceToTaskProfile : Profile
{
    public ResourceToTaskProfile()
    {
        CreateMap<TaskResource, TaskItem>(); 
    }
}
