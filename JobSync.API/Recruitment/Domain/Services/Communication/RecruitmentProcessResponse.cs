using System.Diagnostics;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class RecruitmentProcessResponse: BaseResponse<Process>
{
    public RecruitmentProcessResponse(string message) : base(message)
    {
    }

    public RecruitmentProcessResponse(Process resource) : base(resource)
    {
    }
}