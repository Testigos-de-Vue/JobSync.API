using System.Net.Mime;
using AutoMapper;
using JobSync.API.Activity.Domain.Models;
using JobSync.API.Activity.Domain.Services;
using JobSync.API.Activity.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobSync.API.Activity.Interfaces.Rest.Controllers
{
    [ApiController]
    [Route("api/v1/activity/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Create, read, update and delete Tasks")]
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
        [SwaggerOperation(
            Summary = "Get all tasks",
            Description = "Retrieve all tasks.",
            OperationId = "GetAllTasks",
            Tags = new[] { "Tasks" }
        )]
        public async Task<IEnumerable<TaskResource>> GetAllAsync()
        {
            var tasks = await _taskService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TaskItem>, IEnumerable<TaskResource>>(tasks);
            return resources;
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<TaskResource>), 200)]
        [SwaggerOperation(
            Summary = "Get all tasks by user ID",
            Description = "Retrieve all tasks associated with a specific user.",
            OperationId = "GetAllTasksByUserId",
            Tags = new[] { "Tasks" }
        )]
        public async Task<IEnumerable<TaskResource>> GetAllByUserIdAsync(int userId)
        {
            var tasks = await _taskService.GetTasksByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<TaskItem>, IEnumerable<TaskResource>>(tasks);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskResource), 201)]
        [SwaggerOperation(
            Summary = "Create a new task",
            Description = "Create a new task with the provided details.",
            OperationId = "CreateTask",
            Tags = new[] { "Tasks" }
        )]
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
        [ProducesResponseType(typeof(TaskResource), 200)]
        [SwaggerOperation(
            Summary = "Update an existing task",
            Description = "Update an existing task with the provided details.",
            OperationId = "UpdateTask",
            Tags = new[] { "Tasks" }
        )]
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
        [ProducesResponseType(typeof(TaskResource), 200)]
        [SwaggerOperation(
            Summary = "Delete a task",
            Description = "Delete the task with the specified ID.",
            OperationId = "DeleteTask",
            Tags = new[] { "Tasks" }
        )]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _taskService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var taskResource = _mapper.Map<TaskItem, TaskResource>(result.Resource);

            return Ok(taskResource);
        }
    }
}
