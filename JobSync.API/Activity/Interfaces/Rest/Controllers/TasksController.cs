using System.Net.Mime;
using AutoMapper;
using JobSync.API.Activity.Domain.Models;
using JobSync.API.Activity.Domain.Services;
using JobSync.API.Activity.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Activity.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/activity/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;
    
    public TasksController(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TaskResource>), 200)]
    public async Task<IEnumerable<TaskResource>> GetAllAsync()
    {
        var tasks = await _taskService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TaskItem>, IEnumerable<TaskResource>>(tasks);
        return resources;
    }
    
    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(IEnumerable<TaskResource>), 200)]
    public async Task<IEnumerable<TaskResource>> GetAllByUserIdAsync(int userId)
    {
        var tasks = await _taskService.GetTasksByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<TaskItem>, IEnumerable<TaskResource>>(tasks);
        return resources;
    }




    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] TaskResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var task = _mapper.Map<TaskResource, TaskItem>(resource);
        var result = await _taskService.CreateAsync(task);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var taskResource = _mapper.Map<TaskItem, TaskResource>(result.Resource);
        
        return Created(nameof(PostAsync), taskResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] TaskResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var task = _mapper.Map<TaskResource, TaskItem>(resource);
        var result = await _taskService.UpdateAsync(id, task);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var taskResource = _mapper.Map<TaskItem, TaskResource>(result.Resource);
        
        return Ok(taskResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _taskService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var taskResource = _mapper.Map<TaskItem, TaskResource>(result.Resource);
        
        return Ok(taskResource);
    }
}
