using JobSync.API.Organization.Domain.Repositories;
using JobSync.API.Organization.Domain.Services;
using JobSync.API.Organization.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Organization.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlanRepository _planRepository;
    
    public OrganizationService(IOrganizationRepository organizationRepository
        , IUnitOfWork unitOfWork, IPlanRepository planRepository)
    {
        _organizationRepository = organizationRepository;
        _unitOfWork = unitOfWork;
        _planRepository = planRepository;
    }
    
    public async Task<IEnumerable<Domain.Models.Organization>> ListAsync()
    {
        return await _organizationRepository.ListAsync();
    }
    
    public async Task<Domain.Models.Organization> FindByIdAsync(int id)
    {
        var organization = await _organizationRepository.FindByIdAsync(id);
    
        if (organization == null)
            throw new Exception("Organization not found");

        return organization;
    }
    public async Task<List<int>> GetProfileIdsByOrganizationId(int organizationId)
    {
        var profileIds = await _organizationRepository.GetProfileIdsByOrganizationId(organizationId);
        return profileIds;
    }
    
    public async Task<OrganizationResponse> SaveAsync(Domain.Models.Organization organization)
    {
        var existingOrganization = await _organizationRepository.FindByIdAsync(organization.Id);
        
        if (existingOrganization != null)
            return new OrganizationResponse("An organization already exists with that id");
        
        try
        {
            await _organizationRepository.AddAsync(organization);
            await _unitOfWork.CompleteAsync();
            
            return new OrganizationResponse(organization);
        }
        catch (Exception e)
        {
            return new OrganizationResponse($"An error occurred while saving the organization: {e.Message}");
        }
    }
    
    public async Task<OrganizationResponse> UpdateAsync(int organizationId, Domain.Models.Organization organization)
    {
        // Validate if organization exists
        var existingOrganization = await _organizationRepository.FindByIdAsync(organizationId);
        if (existingOrganization == null)
            return new OrganizationResponse("Organization not found");

        // Validate if plan exists
        var existingPlan = await _planRepository.FindByIdAsync(organization.OrganizationPlanId);
        if (existingPlan == null)
            return new OrganizationResponse("Invalid plan.");
        
        existingOrganization.Name = organization.Name;
        existingOrganization.Email = organization.Email;
        existingOrganization.PhoneNumber = organization.PhoneNumber;
        existingOrganization.LogoUrl = organization.LogoUrl;
        existingOrganization.Address = organization.Address;
        
        try
        {
            _organizationRepository.Update(existingOrganization);
            await _unitOfWork.CompleteAsync();
            
            return new OrganizationResponse(existingOrganization);
        }
        catch (Exception e)
        {
            return new OrganizationResponse($"An error occurred while updating the organization: {e.Message}");
        }
    }

    public async Task<OrganizationResponse> DeleteAsync(int organizationId)
    {
        var existingOrganization = await _organizationRepository.FindByIdAsync(organizationId);

        if (existingOrganization == null)
            return new OrganizationResponse("Organization not found");

        try
        {
            _organizationRepository.Remove(existingOrganization);
            await _unitOfWork.CompleteAsync();
            
            return new OrganizationResponse(existingOrganization);
        }
        catch (Exception e)
        {
            return new OrganizationResponse($"An error occurred while deleting the organization: {e.Message}");
        }
    }
}