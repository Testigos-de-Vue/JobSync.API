using JobSync.API.Activity.Domain.Models;

namespace JobSync.API.Activity.Domain.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> ListAsync(); 
    Task AddAsync(TaskItem taskItem);
    Task<TaskItem> FindByIdAsync(int id);
    Task<IEnumerable<TaskItem>> GetTasksByUserIdAsync(int userId);
    Task<TaskItem> FindByTitleAsync(string title);
    void Update(TaskItem taskItem);
    void Remove(TaskItem taskItem);
}
