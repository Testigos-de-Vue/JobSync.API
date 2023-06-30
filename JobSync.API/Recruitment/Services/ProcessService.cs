using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Recruitment.Services;

public class ProcessService: IProcessService
{
    private readonly IProcessRepository _processRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProcessService(IProcessRepository processRepository, IUnitOfWork unitOfWork)
    {
        this._processRepository = processRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Process>> ListAsync()
    {
        return await _processRepository.ListAsync();
    }

    public Task<Process> FindByIdAsync(int id)
    {
        return _processRepository.FindByIdAsync(id);
    }

    public async Task<ProcessResponse> SaveAsync(Process process)
    {
        try
        {
            await _processRepository.AddAsync(process);
            await _unitOfWork.CompleteAsync();

            return new ProcessResponse(process);
        }
        catch (Exception e)
        {
            return new ProcessResponse($"An error occurred while saving recruitment process : {e.Message}.");
        }
    }

    public async Task<ProcessResponse> UpdateAsync(int id, Process process)
    {
        var existingRecruitmentProcess = await _processRepository.FindByIdAsync(id);

        if (existingRecruitmentProcess == null)
            return new ProcessResponse("Recruitment process not found.");

        try
        {
            _processRepository.Update(existingRecruitmentProcess);
            await _unitOfWork.CompleteAsync();

            return new ProcessResponse(existingRecruitmentProcess);
        }
        catch (Exception e)
        {
            return new ProcessResponse($"An error occurred while updating recruitment process: {e.Message}");
        }
    }

    public async Task<ProcessResponse> DeleteAsync(int id)
    {
        var existingRecruitmentProcess = await _processRepository.FindByIdAsync(id);

        if (existingRecruitmentProcess == null)
            return new ProcessResponse("Recruitment process not found.");

        try
        {
            _processRepository.Remove(existingRecruitmentProcess);
            await _unitOfWork.CompleteAsync();

            return new ProcessResponse(existingRecruitmentProcess);
        }
        catch (Exception e)
        {
            return new ProcessResponse($"An error occurred while deleting recruitment process: {e.Message}");
        }
    }
}