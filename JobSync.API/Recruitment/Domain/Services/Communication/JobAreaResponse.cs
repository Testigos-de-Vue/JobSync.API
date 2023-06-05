using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class JobAreaResponse: BaseResponse<JobArea>
{
    public JobAreaResponse(string message) : base(message)
    {
    }

    public JobAreaResponse(JobArea resource) : base(resource)
    {
    }
}