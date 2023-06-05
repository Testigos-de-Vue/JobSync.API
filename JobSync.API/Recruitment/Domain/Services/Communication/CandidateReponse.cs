using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class CandidateReponse: BaseResponse<Candidate>
{
    public CandidateReponse(string message) : base(message)
    {
    }

    public CandidateReponse(Candidate resource) : base(resource)
    {
    }
}