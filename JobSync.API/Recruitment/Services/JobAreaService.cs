using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Shared.Persistence.Repositories;

namespace JobSync.API.Recruitment.Services;

public class JobAreaService: IJobAreaService
{
    private readonly IJobAreaRepository _jobAreaRepository;
    private readonly UnitOfWork _unitOfWork;
    
    public JobAreaService(IJobAreaRepository jobAreaRepository, UnitOfWork unitOfWork)
    {
        _jobAreaRepository = jobAreaRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<JobArea>> ListAsync()
    {
        return await _jobAreaRepository.ListAsync();
    }

    public async Task<JobAreaResponse> SaveAsync(JobArea jobArea)
    {
        try
        {
            await _jobAreaRepository.AddAsync(jobArea);
            await _unitOfWork.CompleteAsync();

            return new JobAreaResponse(jobArea);
        }
        catch (Exception e)
        {
            return new JobAreaResponse($"An error occurred while saving job area : {e.Message}");
        }
    }

    public async Task<JobAreaResponse> UpdateAsync(int id, JobArea jobArea)
    {
        var existingJobArea = await _jobAreaRepository.FindByIdAsync(id);

        if (existingJobArea == null)
            return new JobAreaResponse($"Job Area nof found.");

        try
        {
            _jobAreaRepository.Update(existingJobArea);
            await _unitOfWork.CompleteAsync();

            return new JobAreaResponse(existingJobArea);
        }
        catch (Exception e)
        {
            return new JobAreaResponse($"An error occurred while updating job area: {e.Message}");
        }
    }

    public async Task<JobAreaResponse> DeleteAsync(int id)
    {
        var existingJobArea = await _jobAreaRepository.FindByIdAsync(id);

        if (existingJobArea == null)
            return new JobAreaResponse($"Job Area nof found.");

        try
        {
            _jobAreaRepository.Remove(existingJobArea);
            await _unitOfWork.CompleteAsync();

            return new JobAreaResponse(existingJobArea);
        }
        catch (Exception e)
        {
            return new JobAreaResponse($"An error occurred while deleting job area: {e.Message}");
        }
    }
}