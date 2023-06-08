using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Shared.Persistence.Repositories;

namespace JobSync.API.Recruitment.Services;

public class PhaseService: IPhaseService
{
    private readonly IPhaseRepository _phaseRepository;
    private readonly UnitOfWork _unitOfWork;

    public PhaseService(IPhaseRepository phaseRepository, UnitOfWork unitOfWork)
    {
        _phaseRepository = phaseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Phase>> ListAsync()
    {
        return await _phaseRepository.ListAsync();
    }

    public async Task<PhaseReponse> SaveAsync(Phase phase)
    {
        try
        {
            await _phaseRepository.AddAsync(phase);
            await _unitOfWork.CompleteAsync();

            return new PhaseReponse(phase);
        }
        catch (Exception e)
        {
            return new PhaseReponse($"An error occurred while saving recruitment phase : {e.Message}");
        }
    }

    public async Task<PhaseReponse> UpdateAsync(int id, Phase phase)
    {
        // Validate if recruitment phase exists
        var existingRecruitmentPhase = await _phaseRepository.FindByIdAsync(id);
        if (existingRecruitmentPhase == null)
            return new PhaseReponse("Recruitment phase not found.");
        
        // Validate if recruitment process exists
        var existingRecruitmentProcess = await _phaseRepository.FinByRecruitmentProcessIdAsync(phase.RecruitmentProcessId);
        if (existingRecruitmentProcess == null)
            return new PhaseReponse("Invalid recruitment process.");
        
        // Perform updates
        existingRecruitmentPhase.Process = phase.Process;
        
        try
        {
            _phaseRepository.Update(existingRecruitmentPhase);
            await _unitOfWork.CompleteAsync();

            return new PhaseReponse(existingRecruitmentPhase);
        }
        catch (Exception e)
        {
            return new PhaseReponse($"An error occurred while updating recruitment phase: {e.Message}");
        }
    }

    public async Task<PhaseReponse> DeleteAsync(int id)
    {
        var existingRecruitmentPhase = await _phaseRepository.FindByIdAsync(id);

        if (existingRecruitmentPhase == null)
            return new PhaseReponse("Recruitment phase not found.");

        try
        {
            _phaseRepository.Remove(existingRecruitmentPhase);
            await _unitOfWork.CompleteAsync();

            return new PhaseReponse(existingRecruitmentPhase);
        }
        catch (Exception e)
        {
            return new PhaseReponse($"An error occurred while deleting recruitment phase: {e.Message}");
        }
    }
}