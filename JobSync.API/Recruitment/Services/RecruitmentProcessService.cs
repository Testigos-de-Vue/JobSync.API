using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Recruitment.Services;

public class RecruitmentProcessService: IRecruitmentProcessService
{
    private readonly IRecruitmentProcessRepository _recruitmentProcessRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecruitmentProcessService(IRecruitmentProcessRepository recruitmentProcessRepository, IUnitOfWork unitOfWork)
    {
        this._recruitmentProcessRepository = recruitmentProcessRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RecruitmentProcess>> ListAsync()
    {
        return await _recruitmentProcessRepository.ListAsync();
    }

    public async Task<RecruitmentProcessResponse> SaveAsync(RecruitmentProcess recruitmentProcess)
    {
        try
        {
            await _recruitmentProcessRepository.AddAsync(recruitmentProcess);
            await _unitOfWork.CompleteAsync();

            return new RecruitmentProcessResponse(recruitmentProcess);
        }
        catch (Exception e)
        {
            return new RecruitmentProcessResponse($"An error occurred while saving recruitment process : {e.Message}");
        }
    }

    public async Task<RecruitmentProcessResponse> UpdateAsync(int id, RecruitmentProcess recruitmentProcess)
    {
        var existingRecruitmentProcess = await _recruitmentProcessRepository.FindByIdAsync(id);

        if (existingRecruitmentProcess == null)
            return new RecruitmentProcessResponse("Recruitment process not found,");

        try
        {
            _recruitmentProcessRepository.Update(existingRecruitmentProcess);
            await _unitOfWork.CompleteAsync();

            return new RecruitmentProcessResponse(existingRecruitmentProcess);
        }
        catch (Exception e)
        {
            return new RecruitmentProcessResponse($"An error occurred while updating recruitment process: {e.Message}");
        }
    }

    public async Task<RecruitmentProcessResponse> DeleteAsync(int id)
    {
        var existingRecruitmentProcess = await _recruitmentProcessRepository.FindByIdAsync(id);

        if (existingRecruitmentProcess == null)
            return new RecruitmentProcessResponse("Recruitment process not found,");

        try
        {
            _recruitmentProcessRepository.Remove(existingRecruitmentProcess);
            await _unitOfWork.CompleteAsync();

            return new RecruitmentProcessResponse(existingRecruitmentProcess);
        }
        catch (Exception e)
        {
            return new RecruitmentProcessResponse($"An error occurred while deleting recruitment process: {e.Message}");
        }
    }
}