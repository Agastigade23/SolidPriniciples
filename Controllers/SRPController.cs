
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SolidPriniciples.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SRPController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public SRPController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet]
    public IActionResult GetAllTasks()
    {
        var tasks = _taskRepository.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetTaskById(int id)
    {
        var task = _taskRepository.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public IActionResult CreateTask(Task task)
    {
        var createdTask = _taskRepository.CreateTask(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, Task task)
    {
        var existingTask = _taskRepository.GetTaskById(id);
        if (existingTask == null)
        {
            return NotFound();
        }
        task.Id = id;
        var updatedTask = _taskRepository.UpdateTask(task);
        return Ok(updatedTask);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        _taskRepository.DeleteTask(id);
        return Ok();
    }
}
