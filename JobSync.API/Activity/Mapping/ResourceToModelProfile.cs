using AutoMapper;
using JobSync.API.Activity.Resources;
using JobSync.API.Activity.Domain.Models;

namespace JobSync.API.Activity.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<TaskResource, TaskItem>(); 
    }
}
