using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Organization.Domain.Services.Communication;

public class OrganizationResponse : BaseResponse<Models.Organization>
{
    public OrganizationResponse(string message) : base(message)
    {
    }

    public OrganizationResponse(Models.Organization resource) : base(resource)
    {
    }
}