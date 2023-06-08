using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class PhaseReponse: BaseResponse<Phase>
{
    public PhaseReponse(string message) : base(message)
    {
    }

    public PhaseReponse(Phase resource) : base(resource)
    {
    }
}