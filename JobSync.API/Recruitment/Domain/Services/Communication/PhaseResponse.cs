using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class PhaseResponse: BaseResponse<Phase>
{
    public PhaseResponse(string message) : base(message)
    {
    }

    public PhaseResponse(Phase resource) : base(resource)
    {
    }
}