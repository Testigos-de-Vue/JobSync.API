using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;
using JobSync.API.Shared.Persistence.Repositories;

namespace JobSync.API.Recruitment.Services;

public class PhaseService: IPhaseService
{
    private readonly IPhaseRepository _phaseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProcessRepository _processRepository;

    public PhaseService(IPhaseRepository phaseRepository, IUnitOfWork unitOfWork, IProcessRepository processRepository)
    {
        _phaseRepository = phaseRepository;
        _unitOfWork = unitOfWork;
        _processRepository = processRepository;
    }

    public async Task<IEnumerable<Phase>> ListAsync()
    {
        return await _phaseRepository.ListAsync();
    }

    public async Task<PhaseResponse> SaveAsync(Phase phase)
    {
        try
        {
            await _phaseRepository.AddAsync(phase);
            await _unitOfWork.CompleteAsync();

            return new PhaseResponse(phase);
        }
        catch (Exception e)
        {
            return new PhaseResponse($"An error occurred while saving recruitment phase : {e.Message}");
        }
    }

    public async Task<PhaseResponse> UpdateAsync(int id, Phase phase)
    {
        // Validate if recruitment phase exists
        var existingPhase = await _phaseRepository.FindByIdAsync(id);
        if (existingPhase == null)
            return new PhaseResponse("Recruitment phase not found.");
        
        // Validate if recruitment process exists
        var existingProcess = await _processRepository.FindByIdAsync(phase.RecruitmentProcessId);
        if (existingProcess == null)
            return new PhaseResponse("Invalid recruitment process.");
        
        // Perform updates
        existingPhase.Process = phase.Process;
        
        try
        {
            _phaseRepository.Update(existingPhase);
            await _unitOfWork.CompleteAsync();

            return new PhaseResponse(existingPhase);
        }
        catch (Exception e)
        {
            return new PhaseResponse($"An error occurred while updating recruitment phase: {e.Message}.");
        }
    }

    public async Task<PhaseResponse> DeleteAsync(int id)
    {
        var existingPhase = await _phaseRepository.FindByIdAsync(id);

        if (existingPhase == null)
            return new PhaseResponse("Recruitment phase not found.");

        try
        {
            _phaseRepository.Remove(existingPhase);
            await _unitOfWork.CompleteAsync();

            return new PhaseResponse(existingPhase);
        }
        catch (Exception e)
        {
            return new PhaseResponse($"An error occurred while deleting recruitment phase: {e.Message}.");
        }
    }

    public async Task<PhaseResponse> PhaseCountByProcessIdAsync(int processId)
    {
        // Validate if recruitment process exists
        var existingProcess = await _processRepository.FindByIdAsync(processId);
        if (existingProcess == null)
            return new PhaseResponse("Invalid recruitment process.");
    
        try
        {
            var phaseCount = _phaseRepository.FinByProcessIdAsync(processId).Result.Count();
            await _unitOfWork.CompleteAsync();

            return new PhaseResponse(phaseCount.ToString());
        }
        catch (Exception e)
        {
            return new PhaseResponse($"An error occurred while getting the count of phases in process with id {processId}: {e.Message}.");
        }
    }

    public async Task<IEnumerable<Phase>> ListByProcessIdAsync(int processId)
    {
        return await _phaseRepository.FinByProcessIdAsync(processId);
    }
}