using JobSync.API.Organization.Domain.Repositories;
using JobSync.API.Organization.Domain.Services;
using JobSync.API.Organization.Domain.Services.Communication;
using JobSync.API.Organization.Domain.Models;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Organization.Services;

public class PlanService : IPlanService
{
    private readonly IPlanRepository _planRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlanService(IPlanRepository planRepository, IUnitOfWork unitOfWork)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Plan>> ListAsync()
    {
        return await _planRepository.ListAsync();
    }
    
    public async Task<PlanResponse> SaveAsync(Plan plan)
    {
        try
        {
            await _planRepository.AddAsync(plan);
            await _unitOfWork.CompleteAsync();
      
            return new PlanResponse(plan);
        }
        catch (Exception e)
        {
            return new PlanResponse($"An error occurred while saving the plan: {e.Message}");
        }
    }
    
    public async Task<PlanResponse> UpdateAsync(int id, Plan plan)
    {
        var existingPlan = await _planRepository.FindByIdAsync(id);

        if (existingPlan == null)
            return new PlanResponse("Plan not found");

        existingPlan.Name = plan.Name;
        
        var existingPlanWithTitle = await _planRepository.FindByNameAsync(plan.Name);

        if (existingPlan != null)
            return new PlanResponse("Plan Name is already used");

        try
        {
            _planRepository.Update(existingPlan);
            await _unitOfWork.CompleteAsync();

            return new PlanResponse(existingPlan);
        }
        catch (Exception e)
        {
            return new PlanResponse($"An error occurred while updating the plan: {e.Message}");
        }
    }
    
    public async Task<PlanResponse> DeleteAsync(int planId)
    {
        var existingPlan = await _planRepository.FindByIdAsync(planId);

        if (existingPlan == null)
            return new PlanResponse("Plan not found");

        try
        {
            _planRepository.Remove(existingPlan);
            await _unitOfWork.CompleteAsync();

            return new PlanResponse(existingPlan);
        }
        catch (Exception e)
        {
            return new PlanResponse($"An error occurred while deleting the plan: {e.Message}");
        }
    }
    
    
}