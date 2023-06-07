using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Recruitment.Persistence.Repositories;

public class CandidateProfileRepository: BaseRepository, ICandidateProfileRepository
{
    public CandidateProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CandidateProfile>> ListAsync()
    {
        return await Context.CandidateProfiles
            .Include(c => c.JobArea)
            .Include(c=> c.RecruitmentPhase)
            .ToListAsync();
    }

    public async Task AddAsync(CandidateProfile candidateProfile)
    {
        await Context.CandidateProfiles.AddAsync(candidateProfile);
    }

    public async Task<CandidateProfile> FindByIdAsync(int candidateProfileId)
    {
        return await Context.CandidateProfiles
            .Include(c => c.JobArea)
            .Include(c => c.RecruitmentPhase)
            .FirstOrDefaultAsync(c => c.Id == candidateProfileId);
    }

    public async Task<IEnumerable<CandidateProfile>> FindByJobAreaIdAsync(int jobAreaId)
    {
        return await Context.CandidateProfiles
            .Where(c => c.JobAreaId == jobAreaId)
            .Include(c => c.JobArea)
            .ToListAsync();
    }

    public async Task<IEnumerable<CandidateProfile>> FindByRecruitmentPhaseIdAsync(int phaseId)
    {
        return await Context.CandidateProfiles
            .Where(c => c.RecruitmentPhaseId == phaseId)
            .Include(c => c.RecruitmentPhase)
            .ToListAsync();
    }

    public void Update(CandidateProfile candidateProfile)
    {
        Context.CandidateProfiles.Update(candidateProfile);
    }

    public void Remove(CandidateProfile candidateProfile)
    {
        Context.CandidateProfiles.Remove(candidateProfile);
    }
}