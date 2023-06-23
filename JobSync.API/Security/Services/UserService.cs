using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Domain.Repositories;
using JobSync.API.Security.Domain.Services;
using JobSync.API.Security.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Security.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  private readonly IUnitOfWork _unitOfWork;

  public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
  {
    _userRepository = userRepository;
    _unitOfWork = unitOfWork;
  }
  
  public async Task<IEnumerable<User>> ListAsync()
  {
    return await _userRepository.ListAsync();
  }

  public async Task<UserResponse> CreateAsync(User user)
  {
    try
    {
      await _userRepository.AddAsync(user);
      await _unitOfWork.CompleteAsync();
      
      return new UserResponse(user);
    }
    catch (Exception e)
    {
      return new UserResponse($"An error occurred while saving the user: {e.Message}");
    }
  }

  public async Task<UserResponse> UpdateAsync(int id, User user)
  {
    var existingUser = await _userRepository.FindByIdAsync(id);

    if (existingUser == null)
      return new UserResponse("User not found");

    existingUser.Name = user.Name;
    existingUser.LastName = user.LastName;
    existingUser.Email = user.Email;
    existingUser.ImageUrl = user.ImageUrl;
    existingUser.PhoneNumber = user.PhoneNumber;
    existingUser.IsSubscribedToNewsletter = user.IsSubscribedToNewsletter;
    existingUser.Password = user.Password;

    try
    {
      _userRepository.Update(existingUser);
      await _unitOfWork.CompleteAsync();

      return new UserResponse(existingUser);
    }
    catch (Exception e)
    {
      return new UserResponse($"An error occurred while updating the user: {e.Message}");
    }
  }

  public async Task<UserResponse> DeleteAsync(int id)
  {
    var existingUser = await _userRepository.FindByIdAsync(id);

    if (existingUser == null)
      return new UserResponse("User not found");

    try
    {
      _userRepository.Remove(existingUser);
      await _unitOfWork.CompleteAsync();

      return new UserResponse(existingUser);
    }
    catch (Exception e)
    {
      return new UserResponse($"An error occurred while deleting the user: {e.Message}");
    }
  }
}
