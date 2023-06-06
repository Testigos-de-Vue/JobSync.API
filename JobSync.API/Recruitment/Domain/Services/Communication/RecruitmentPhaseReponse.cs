using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class RecruitmentPhaseReponse: BaseResponse<RecruitmentPhase>
{
    public RecruitmentPhaseReponse(string message) : base(message)
    {
    }

    public RecruitmentPhaseReponse(RecruitmentPhase resource) : base(resource)
    {
    }
}