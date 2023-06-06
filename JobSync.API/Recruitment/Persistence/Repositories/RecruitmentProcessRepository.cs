using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Recruitment.Persistence.Repositories;

public class RecruitmentProcessRepository: BaseRepository, IRecruitmentProcessRepository
{
    public RecruitmentProcessRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RecruitmentProcess>> ListAsync()
    {
        return await Context.Processes
            .Include(p => p.Phases)
            .ToListAsync();
    }

    public async Task AddAsync(RecruitmentProcess recruitmentProcess)
    {
        await Context.Processes.AddAsync(recruitmentProcess);
    }

    public async Task<RecruitmentProcess> FindByIdAsync(int processId)
    {
        return await Context.Processes
            .Include(p => p.Phases)
            .FirstOrDefaultAsync(p => p.Id == processId);
    }

    public void Update(RecruitmentProcess recruitmentProcess)
    {
        Context.Processes.Update(recruitmentProcess);
    }

    public void Remove(RecruitmentProcess recruitmentProcess)
    {
        Context.Processes.Remove(recruitmentProcess);
    }
}