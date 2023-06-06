using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Shared.Persistence.Repositories;

namespace JobSync.API.Recruitment.Services;

public class RecruitmenPhaseService: IRecruitmentPhaseService
{
    private readonly IRecruitmentPhaseRepository _recruitmentPhaseRepository;
    private readonly UnitOfWork _unitOfWork;

    public RecruitmenPhaseService(IRecruitmentPhaseRepository recruitmentPhaseRepository, UnitOfWork unitOfWork)
    {
        _recruitmentPhaseRepository = recruitmentPhaseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RecruitmentPhase>> ListAsync()
    {
        return await _recruitmentPhaseRepository.ListAsync();
    }

    public async Task<RecruitmentPhaseReponse> SaveAsync(RecruitmentPhase recruitmentPhase)
    {
        try
        {
            await _recruitmentPhaseRepository.AddAsync(recruitmentPhase);
            await _unitOfWork.CompleteAsync();

            return new RecruitmentPhaseReponse(recruitmentPhase);
        }
        catch (Exception e)
        {
            return new RecruitmentPhaseReponse($"An error occurred while saving recruitment phase : {e.Message}");
        }
    }

    public async Task<RecruitmentPhaseReponse> UpdateAsync(int id, RecruitmentPhase recruitmentPhase)
    {
        // Validate if recruitment phase exists
        var existingRecruitmentPhase = await _recruitmentPhaseRepository.FindByIdAsync(id);
        if (existingRecruitmentPhase == null)
            return new RecruitmentPhaseReponse("Recruitment phase not found.");
        
        // Validate if recruitment process exists
        var existingRecruitmentProcess = await _recruitmentPhaseRepository.FinByRecruitmentProcessIdAsync(recruitmentPhase.RecruitmentProcessId);
        if (existingRecruitmentProcess == null)
            return new RecruitmentPhaseReponse("Invalid recruitment process.");
        
        // Perform updates
        existingRecruitmentPhase.RecruitmentProcess = recruitmentPhase.RecruitmentProcess;
        
        try
        {
            _recruitmentPhaseRepository.Update(existingRecruitmentPhase);
            await _unitOfWork.CompleteAsync();

            return new RecruitmentPhaseReponse(existingRecruitmentPhase);
        }
        catch (Exception e)
        {
            return new RecruitmentPhaseReponse($"An error occurred while updating recruitment phase: {e.Message}");
        }
    }

    public async Task<RecruitmentPhaseReponse> DeleteAsync(int id)
    {
        var existingRecruitmentPhase = await _recruitmentPhaseRepository.FindByIdAsync(id);

        if (existingRecruitmentPhase == null)
            return new RecruitmentPhaseReponse("Recruitment phase not found.");

        try
        {
            _recruitmentPhaseRepository.Remove(existingRecruitmentPhase);
            await _unitOfWork.CompleteAsync();

            return new RecruitmentPhaseReponse(existingRecruitmentPhase);
        }
        catch (Exception e)
        {
            return new RecruitmentPhaseReponse($"An error occurred while deleting recruitment phase: {e.Message}");
        }
    }
}