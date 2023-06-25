using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Recruitment.Persistence.Repositories;

public class PhaseRepository: BaseRepository, IPhaseRepository
{
    public PhaseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Phase>> ListAsync()
    {
        return await Context.Phases
            .Include(p => p.Process)
            .ToListAsync();
    }

    public async Task AddAsync(Phase phase)
    {
        await Context.Phases.AddAsync(phase);
    }

    public async Task<Phase> FindByIdAsync(int phaseId)
    {
        return await Context.Phases
            .Include(p => p.Process)
            .FirstOrDefaultAsync(p => p.Id == phaseId);
    }

    public async Task<IEnumerable<Phase>> FinByProcessIdAsync(int processId)
    {
        return await Context.Phases
            .Where(p => p.ProcessId == processId)
            .Include(p => p.Process)
            .ToListAsync();
    }

    public void Update(Phase phase)
    {
        Context.Phases.Update(phase);
    }

    public void Remove(Phase phase)
    {
        Context.Phases.Remove(phase);
    }
}