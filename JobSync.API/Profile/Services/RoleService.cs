using JobSync.API.Profile.Domain.Models;
using JobSync.API.Profile.Domain.Repositories;
using JobSync.API.Profile.Domain.Services;
using JobSync.API.Profile.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Profile.Services;

public class RoleService : IRoleService
{
  private readonly IRoleRepository _roleRepository;
  private readonly IUnitOfWork _unitOfWork;

  public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
  {
    _roleRepository = roleRepository;
    _unitOfWork = unitOfWork;
  }
  
  public async Task<IEnumerable<Role>> ListAsync()
  {
    return await _roleRepository.ListAsync();
  }

  public async Task<RoleResponse> SaveAsync(Role role)
  {
    try
    {
      await _roleRepository.AddAsync(role);
      await _unitOfWork.CompleteAsync();

      return new RoleResponse(role);
    }
    catch (Exception e)
    {
      return new RoleResponse($"An error occurred while saving the role: {e.Message}");
    }
  }

  public async Task<RoleResponse> UpdateAsync(int roleId, Role role)
  {
    var existingRole = await _roleRepository.FindByIdAsync(roleId);

    if (existingRole == null)
      return new RoleResponse("Role not found");

    var existingRoleWithTitle = await _roleRepository.FindByNameAsync(role.Name);

    if (existingRole != null)
      return new RoleResponse("Title is already used");

    existingRole.Name = role.Name;
    
    try
    {
      _roleRepository.Update(existingRole);
      await _unitOfWork.CompleteAsync();

      return new RoleResponse(existingRole);
    }
    catch (Exception e)
    {
      return new RoleResponse($"An error occurred while updating the tutorial: {e.Message}");
    }
  }

  public async Task<RoleResponse> DeleteAsync(int roleId)
  {
    var existingRole = await _roleRepository.FindByIdAsync(roleId);

    if (existingRole == null)
      return new RoleResponse("Role not found");

    try
    {
      _roleRepository.Remove(existingRole);
      await _unitOfWork.CompleteAsync();

      return new RoleResponse(existingRole);
    }
    catch (Exception e)
    {
      return new RoleResponse($"An error occurred while deleting the tutorial: {e.Message}");
    }
  }
}