using System.Diagnostics;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public class ProcessResponse: BaseResponse<Process>
{
    public ProcessResponse(string message) : base(message)
    {
    }

    public ProcessResponse(Process resource) : base(resource)
    {
    }
}