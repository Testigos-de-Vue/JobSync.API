using JobSync.API.Activity.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Activity.Domain.Services.Communication;

public class TaskResponse : BaseResponse<TaskItem>
{
    public TaskResponse (string message) : base(message){}
    public TaskResponse (TaskItem resource) : base(resource){}
}
