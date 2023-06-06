using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Recruitment.Persistence.Repositories;

public class ProcessRepository: BaseRepository, IProcessRepository
{
    public ProcessRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Process>> ListAsync()
    {
        return await Context.Processes
            .Include(p => p.Phases)
            .ToListAsync();
    }

    public async Task AddAsync(Process process)
    {
        await Context.Processes.AddAsync(process);
    }

    public async Task<Process> FindByIdAsync(int processId)
    {
        return await Context.Processes
            .Include(p => p.Phases)
            .FirstOrDefaultAsync(p => p.Id == processId);
    }

    public void Update(Process process)
    {
        Context.Processes.Update(process);
    }

    public void Remove(Process process)
    {
        Context.Processes.Remove(process);
    }
}