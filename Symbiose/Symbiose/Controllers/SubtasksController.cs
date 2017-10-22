using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Symbiose.Services.Interfaces;
using Symbiose.Data.Models.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Symbiose.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symbiose.Controllers
{
    [Route("api/[controller]")]
    public class SubtasksController : Controller
    {
        protected ITaskService TaskService { get; set; }

        public SubtasksController(ITaskService taskService)
        {
            TaskService = taskService;
        }

        // GET: /api/subtasks/{id}
        [HttpGet]
        public async Task<IActionResult> GetSubtaskById(int id)
        {
            try
            {
                var subtask = await TaskService.GetByIdAsync<Subtask>(id);

                if (subtask == null)
                {
                    return NotFound();
                }

                return Ok(subtask);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: /api/subtasks/parent/{parentId}
        [HttpGet("parent/{parentId}")]
        public async Task<IActionResult> GetSubtasksByParent(int parentId, int take = 0, int skip = 0)
        {
            try
            {
                List<Subtask> subtasks;

                if (take > 0)
                {
                    subtasks = await TaskService.GetSubtasksOfTask(parentId).Where(c => c.ParentId == parentId).Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    subtasks = await TaskService.GetSubtasksOfTask(parentId).ToListAsync();
                }

                if (subtasks.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(subtasks);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: /api/subtasks/user/{userId}&{take}&{skip}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetSubtasksByUserAsync(int userId, int take = 0, int skip = 0)
        {
            try
            {
                List<Subtask> subtasks;
                if (take > 0)
                {
                    subtasks = await TaskService.Set<Subtask>().Where(c => c.AssigneeId == userId).Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    subtasks = await TaskService.GetSubtasksByUser(userId).ToListAsync();
                }

                if (subtasks.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(subtasks);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //POST: /api/Subtasks/AddNewSubtask
        [HttpPost("AddNewSubtask")]
        public async Task<IActionResult> AddNewTopic([FromBody] Subtask subtask)
        {
            try
            {
                await TaskService.AddAsync<Subtask>(subtask);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Topic Added!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }
    }
}
