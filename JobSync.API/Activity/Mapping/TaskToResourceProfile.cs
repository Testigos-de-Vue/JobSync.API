using AutoMapper;
using JobSync.API.Activity.Resources;
using JobSync.API.Activity.Domain.Models;


namespace JobSync.API.Activity.Mapping;

public class TaskToResourceProfile : Profile
{
    public TaskToResourceProfile()
    {
        CreateMap<TaskItem, TaskResource>();
    }
}
