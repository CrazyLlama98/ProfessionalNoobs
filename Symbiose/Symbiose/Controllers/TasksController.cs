using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Symbiose.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Symbiose.Data.Models.Application;

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
                if (task == null)
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

        // GET: /api/tasks/project/{projectId}&{take}&{skip}
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetTasksByProjectAsync(int projectId, int take = 0, int skip = 0)
        {
            try
            {
                List<Data.Models.Application.Task> projectTasks;
                if (take > 0)
                {
                    projectTasks = await TaskService.Set<Data.Models.Application.Task>().Where(c => c.ProjectId == projectId).Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    projectTasks = await TaskService.GetTasksByProject(projectId).ToListAsync();
                }

                if (projectTasks.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(projectTasks);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: /api/tasks/user/{userId}&{take}&{skip}
        [HttpGet("user")]
        public async Task<IActionResult> GetTasksOfUserAsync(int userId, int take = 0, int skip = 0)
        {
            try
            {
                List<Data.Models.Application.Task> userTasks;
                if (take > 0)
                {
                    userTasks = await TaskService.Set<Data.Models.Application.Task>().Where(c => c.AssigneeId == userId).Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    userTasks = await TaskService.GetTasksByUser(userId).ToListAsync();
                }
                
                if (userTasks.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(userTasks);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: /api/tasks/project/{projectId}&{userId}&{take}&{skip}
        [HttpGet("project/user")]
        public async Task<IActionResult> GetTasksByProjectAndUserAsync(int projectId, int userId, int take = 0, int skip = 0)
        {
            try
            {
                List<Data.Models.Application.Task> tasks;
                if (take > 0)
                {
                    tasks = await TaskService.Set<Data.Models.Application.Task>().Where(c => c.ProjectId == projectId && c.AssigneeId == userId).Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    tasks = await TaskService.GetTasksByProject(projectId).ToListAsync();
                }

                if (tasks.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(tasks);
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

        // POST: /api/tasks/AddNewComment
        [HttpPost("AddNewComment")]
        public async Task<IActionResult> AddNewTaskComment([FromBody] TaskComment comment)
        {
            try
            {
                await TaskService.AddAsync(comment);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Task Comment Added!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

        // POST: /api/tasks/edit/{taskId}
        [HttpPost("edit/{taskId}")]
        public async Task<IActionResult> EditTask(int taskId, [FromBody] Data.Models.Application.Task task)
        {
            try
            {
                await TaskService.UpdateAsync<Data.Models.Application.Task>(taskId, task);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Task Edited!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

        // GET: /api/tasks/comments/{taskId}
        [HttpPost("comments/{taskId}")]
        public async Task<IActionResult> GetTaskComments(int taskId)
        {
            try
            {
                var comments = await TaskService.GetTaskComments(taskId).ToListAsync();

                if (comments.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(comments);
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }
    }
}
