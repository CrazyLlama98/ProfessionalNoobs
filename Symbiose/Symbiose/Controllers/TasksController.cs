using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Symbiose.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symbiose.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        protected ITaskService TaskService { get; set; }

        public TasksController(ITaskService taskService)
        {
            TaskService = taskService;
        }

        // GET: /api/tasks/{taskId}
        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            try
            {
                var task = await TaskService.GetByIdAsync<Data.Models.Application.Task>(taskId);
                if (task != null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: /api/tasks/project/{projectId}
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetTasksByProjectAsync(int projectId)
        {
            try
            {
                return Ok(await TaskService.GetTasksByProject(projectId).ToListAsync());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: /api/tasks/user
        [HttpGet("user")]
        public async Task<IActionResult> GetTasksOfUserAsync(int userId, int projectId = 0)
        {
            try
            {
                var userTasks = await TaskService.GetTasksByUser(userId).ToListAsync();
                if (userTasks.Count() > 0)
                {
                    if (projectId != 0)
                    {
                        userTasks = userTasks.Where(c => c.ProjectId == projectId).ToList();
                        if (userTasks.Count() == 0)
                        {
                            return Ok(new List<Data.Models.Application.Task>());
                        }
                    }
                    return Ok(userTasks);
                }
                return Ok(new List<Data.Models.Application.Task>());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: /api/tasks/AddNewTask
        [HttpPost("AddNewTask")]
        public async Task<IActionResult> AddNewTask([FromBody] Data.Models.Application.Task task)
        {
            try
            {
                await TaskService.AddAsync(task);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Task Added!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

    }
}
