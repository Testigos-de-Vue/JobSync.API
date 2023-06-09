using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Organization.Domain.Services.Communication;

public class PlanResponse : BaseResponse<Models.Plan>
{
    public PlanResponse(string message) : base(message)
    {
    }

    public PlanResponse(Models.Plan resource) : base(resource)
    {
    }
}