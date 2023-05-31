using AutoMapper;
using JobSync.API.Activity.Domain.Models;
using JobSync.API.Activity.Resources;

namespace JobSync.API.Activity.Mapping;

public class TaskToResourceProfile : Profile
{
    public TaskToResourceProfile()
    {
        CreateMap<TaskItem, TaskResource>();
    }
}