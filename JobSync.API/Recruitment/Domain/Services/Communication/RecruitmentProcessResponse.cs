using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class RecruitmentProcessResponse: BaseResponse<RecruitmentProcess>
{
    public RecruitmentProcessResponse(string message) : base(message)
    {
    }

    public RecruitmentProcessResponse(RecruitmentProcess resource) : base(resource)
    {
    }
}