using AutoMapper;
using JobSync.API.Activity.Domain.Models;
using JobSync.API.Activity.Resources;

namespace JobSync.API.Activity.Mapping;

public class ResourceToTaskProfile : Profile
{
    public ResourceToTaskProfile()
    {
        CreateMap<TaskResource, TaskItem>(); 
    }
}