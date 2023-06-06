using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Shared.Persistence.Repositories;

namespace JobSync.API.Recruitment.Services;

public class CandidateProfileService: ICandidateProfileService
{
    private readonly ICandidateProfileRepository _candidateProfileRepository;
    private readonly UnitOfWork _unitOfWork;
    
    public CandidateProfileService(ICandidateProfileRepository candidateProfileRepository, UnitOfWork unitOfWork)
    {
        _candidateProfileRepository = candidateProfileRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<CandidateProfile>> ListAsync()
    {
        return await _candidateProfileRepository.ListAsync();
    }

    public async Task<CandidateProfileReponse> SaveAsync(CandidateProfile candidateProfile)
    {
        try
        {
            await _candidateProfileRepository.AddAsync(candidateProfile);
            await _unitOfWork.CompleteAsync();
            
            return new CandidateProfileReponse(candidateProfile);
        }
        catch (Exception e)
        {
            return new CandidateProfileReponse($"An error occurred while saving candidate profile : {e.Message}");
        }
    }

    public async Task<CandidateProfileReponse> UpdateAsync(int id, CandidateProfile candidateProfile)
    {
        // Validate if candidate profile exists
        var existingCandidateProfile = await _candidateProfileRepository.FindByIdAsync(id);
        if (existingCandidateProfile == null)
            return new CandidateProfileReponse($"Candidate Profile not found.");
        
        // Validate if job area exists
        var existingJobArea = await _candidateProfileRepository.FindByJobAreaIdAsync(candidateProfile.JobAreaId);
        if (existingJobArea == null)
            return new CandidateProfileReponse($"Invalid Job Area.");
        
        // Validate if user exists
        var existingUser = await _candidateProfileRepository.FindByUserIdAsync(candidateProfile.UserId);
        if (existingUser == null)
            return new CandidateProfileReponse($"Invalid User.");
        
        // Update fields
        existingCandidateProfile.JobArea = candidateProfile.JobArea;
        existingCandidateProfile.User = candidateProfile.User;
        
        try
        {
            _candidateProfileRepository.Update(existingCandidateProfile);
            await _unitOfWork.CompleteAsync();

            return new CandidateProfileReponse(existingCandidateProfile);
        }
        catch (Exception e)
        {
            return new CandidateProfileReponse($"An error occurred while updating candidate profile: {e.Message}");
        }
    }

    public async Task<CandidateProfileReponse> DeleteAsync(int id)
    {
        var existingCandidateProfile = await _candidateProfileRepository.FindByIdAsync(id);

        if (existingCandidateProfile == null)
            return new CandidateProfileReponse($"Candidate Profile not found.");

        try
        {
            _candidateProfileRepository.Remove(existingCandidateProfile);
            await _unitOfWork.CompleteAsync();

            return new CandidateProfileReponse(existingCandidateProfile);
        }
        catch (Exception e)
        {
            return new CandidateProfileReponse($"An error occurred while deleting candidate profile: {e.Message}");
        }
    }
}