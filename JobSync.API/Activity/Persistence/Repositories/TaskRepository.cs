using JobSync.API.Activity.Domain.Models;
using JobSync.API.Activity.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Activity.Persistence.Repositories;

public class TaskRepository :BaseRepository, ITaskRepository
{
    public TaskRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskItem>> ListAsync()
    {
        return await Context.TaskItems.ToListAsync();
    }

    public async Task AddAsync(TaskItem taskItem)
    {
        await Context.TaskItems.AddAsync(taskItem);
    }
    
    public async Task<TaskItem> FindByIdAsync(int id)
    {
        return await Context.TaskItems.FindAsync(id);
    }
    
    public async Task<TaskItem> FindByTitleAsync(string title)
    {
        return await Context.TaskItems
            .Include(t => t.Title)
            .FirstOrDefaultAsync(t => t.Title == title);
    }
    
    public void Update(TaskItem taskItem)
    {
        Context.TaskItems.Update(taskItem);
    }
    
    public void Remove(TaskItem taskItem)
    {
        Context.TaskItems.Remove(taskItem);
    }
}
