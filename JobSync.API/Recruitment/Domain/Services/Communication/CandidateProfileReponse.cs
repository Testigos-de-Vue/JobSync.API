using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class CandidateProfileReponse: BaseResponse<CandidateProfile>
{
    public CandidateProfileReponse(string message) : base(message)
    {
    }

    public CandidateProfileReponse(CandidateProfile resource) : base(resource)
    {
    }
}