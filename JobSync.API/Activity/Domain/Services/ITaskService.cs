using JobSync.API.Activity.Domain.Models;
using JobSync.API.Activity.Domain.Services.Communication;

namespace JobSync.API.Activity.Domain.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> ListAsync();
    Task<TaskItem> FIndByIdAsync(int id);
    Task<IEnumerable<TaskItem>> GetTasksByUserIdAsync(int userId);
    Task<TaskResponse> CreateAsync(TaskItem taskItem);
    Task<TaskResponse> UpdateAsync(int id, TaskItem taskItem);
    Task<TaskResponse> DeleteAsync(int id);
}
