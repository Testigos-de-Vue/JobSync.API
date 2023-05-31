using JobSync.API.Activity.Domain.Models;
using JobSync.API.Activity.Domain.Repositories;
using JobSync.API.Activity.Domain.Services;
using JobSync.API.Activity.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Activity.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public TaskService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<TaskItem>> ListAsync()
    {
        return await _taskRepository.ListAsync();
    }
    
    public async Task<TaskResponse> CreateAsync(TaskItem task)
    {
        try
        {
            await _taskRepository.AddAsync(task);
            await _unitOfWork.CompleteAsync();

            return new TaskResponse(task);
        }
        catch (Exception e)
        {
            return new TaskResponse($"An error occurred while saving the task: {e.Message}");
        }
        
    }

    public async Task<TaskResponse> UpdateAsync(int id, TaskItem task)
    {
        var existingTaskItem = await _taskRepository.FindByIdAsync(id);

        if (existingTaskItem == null)
            return new TaskResponse("Task not found");

        var existingTaskWithTitle = await _taskRepository.FindByTitleAsync(task.Title);

        if (existingTaskWithTitle != null && existingTaskWithTitle.Id != id)
            return new TaskResponse("There is already a task with the same title");
        
        
        existingTaskItem.Title = task.Title;
        existingTaskItem.Description = task.Description;
        
        try 
        {
            _taskRepository.Update(existingTaskItem);
            await _unitOfWork.CompleteAsync();

            return new TaskResponse(existingTaskItem);
        }
        catch (Exception e)
        {
            return new TaskResponse($"An error occurred while updating the task: {e.Message}");
        }
    }

    public async Task<TaskResponse> DeleteAsync(int id)
    {
        var existingTaskItem = await _taskRepository.FindByIdAsync(id);

        if (existingTaskItem == null)
            return new TaskResponse("Task not found");

        try
        {
            _taskRepository.Remove(existingTaskItem);
            await _unitOfWork.CompleteAsync();

            return new TaskResponse(existingTaskItem);
        }
        catch (Exception e)
        {
            return new TaskResponse($"An error occurred while deleting the task: {e.Message}");
        }
    }
    
}
