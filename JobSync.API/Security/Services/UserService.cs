using AutoMapper;
using JobSync.API.Security.Authorization.Handlers.Interfaces;
using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Domain.Repositories;
using JobSync.API.Security.Domain.Services;
using JobSync.API.Security.Domain.Services.Communication;
using JobSync.API.Security.Exceptions;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Security.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  private readonly IPasswordHashingService _passwordHashingService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IJwtHandler _jwtHandler;
  private readonly IMapper _mapper;
  
  public UserService(IUserRepository userRepository, IPasswordHashingService passwordHashingService, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
  {
    _passwordHashingService = passwordHashingService;
    _userRepository = userRepository;
    _unitOfWork = unitOfWork;
    _jwtHandler = jwtHandler;
    _mapper = mapper;
  }

  public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model)
  {
    var user = await _userRepository.FindByEmailAsync(model.Email);

    if (user == null || !_passwordHashingService.VerifyPassword(model.Password, user.PasswordHash))
      throw new AppException("Invalid username or password");
    
    var response = _mapper.Map<AuthenticateResponse>(user);
    response.Token = _jwtHandler.GenerateToken(user);
    
    return response;
  }

  public async Task<IEnumerable<User>> ListAsync()
  {
    return await _userRepository.ListAsync();
  }

  public async Task<User> GetByIdAsync(int id)
  {
    var user = await _userRepository.FindByIdAsync(id);
    
    if (user == null) 
      throw new AppException("User not found");
    
    return user;
  }

  public async Task RegisterAsync(RegisterRequest model)
  {
    if (_userRepository.ExistsByEmail(model.Email))
      throw new AppException($"Email '{model.Email}'is already taken");
        
    var user = _mapper.Map<User>(model);
    user.PasswordHash = _passwordHashingService.GetHash(model.Password);
        
    try
    {
      await _userRepository.AddAsync(user);
      await _unitOfWork.CompleteAsync();
    }
    catch (Exception e)
    {
      throw new AppException($"An error occurred while saving the user: {e.Message}");
    }
  }

  public async Task UpdateAsync(int id, UpdateRequest model)
  {
    var user = GetById(id);
    var existingUserWithEmail = await _userRepository.FindByEmailAsync(model.Email);
    
    if (existingUserWithEmail != null && !existingUserWithEmail.Email.Equals(model.Email))
      throw new AppException($"Email '{model.Email}' is already taken");
        
    if(!string.IsNullOrEmpty(model.Password))
      user.PasswordHash = _passwordHashingService.GetHash(model.Password);
        
    _mapper.Map(model, user);
    
    try
    {
      _userRepository.Update(user);
      await _unitOfWork.CompleteAsync();
    }
    catch (Exception e)
    {
      throw new AppException($"An error occurred while updating the user: {e.Message}");
    }
  }

  public Task DeleteAsync(int id)
  {
    var user = GetById(id);
    
    try
    {
      _userRepository.Remove(user);
      return _unitOfWork.CompleteAsync();
    }
    catch (Exception e)
    {
      throw new AppException($"An error occurred while deleting the user: {e.Message}");
    }
  }
  
  private User GetById(int id)
  {
    var user = _userRepository.FindById(id);
    if (user == null) throw new KeyNotFoundException("User not found");
    return user;
  }
}
