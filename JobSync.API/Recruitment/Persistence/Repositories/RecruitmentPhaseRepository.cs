using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Recruitment.Persistence.Repositories;

public class RecruitmentPhaseRepository: BaseRepository, IRecruitmentPhaseRepository
{
    public RecruitmentPhaseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RecruitmentPhase>> ListAsync()
    {
        return await Context.Phases
            .Include(p => p.RecruitmentProcess)
            .Include(p => p.CandidateProfiles)
            .ToListAsync();
    }

    public async Task AddAsync(RecruitmentPhase recruitmentPhase)
    {
        await Context.Phases.AddAsync(recruitmentPhase);
    }

    public async Task<RecruitmentPhase> FindByIdAsync(int phaseId)
    {
        return await Context.Phases
            .Include(p => p.RecruitmentProcess)
            .Include(p => p.CandidateProfiles)
            .FirstOrDefaultAsync(p => p.Id == phaseId);
    }

    public async Task<IEnumerable<RecruitmentPhase>> FinByRecruitmentProcessIdAsync(int processId)
    {
        return await Context.Phases
            .Where(p => p.RecruitmentProcessId == processId)
            .Include(p => p.RecruitmentProcess)
            .ToListAsync();
    }

    public void Update(RecruitmentPhase recruitmentPhase)
    {
        Context.Phases.Update(recruitmentPhase);
    }

    public void Remove(RecruitmentPhase recruitmentPhase)
    {
        Context.Phases.Remove(recruitmentPhase);
    }
}