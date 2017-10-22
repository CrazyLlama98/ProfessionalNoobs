using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Symbiose.Services;
using Symbiose.Data.Models.Application;
using Symbiose.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symbiose.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        public IProjectService ProjectService { get; set; }

        public ProjectsController(IProjectService projectService)
        {
            ProjectService = projectService;
        }

        // GET - /api/Projects/ 
        [HttpGet]
        public async Task<IActionResult> GetProjectsAsync(int take = 0, int skip = 0)
        {
            try
            {
                List<Project> projects;

                if (take > 0)
                {
                    projects = await ProjectService.Set<Project>().Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    projects = await ProjectService.Set<Project>().ToListAsync();
                }

                if (projects.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(await ProjectService.GetAllAsync<Project>());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET - /api/Projects/user 
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetProjectsByUserAsync(int userId, int take = 0, int skip = 0)
        {
            try
            {
                List<Project> projects;

                if (take > 0)
                {
                    projects = await (await ProjectService.GetProjectsOfUser(userId)).Skip(skip).Take(take).ToListAsync();
                }
                else
                {
                    projects = await (await ProjectService.GetProjectsOfUser(userId)).ToListAsync();
                }

                if (projects.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(projects);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST - /api/Projects/addNewProject
        [HttpPost("addNewProject")]
        public async Task<IActionResult> AddNewProject([FromBody] Project project)
        {
            try
            {
                await ProjectService.AddAsync(project);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Project Added!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

        // POST: /api/Projects/edit/{projectId}
        [HttpPost("edit/{projectId}")]
        public async Task<IActionResult> EditProject(int projectId, [FromBody] Project project)
        {
            try
            {
                await ProjectService.UpdateAsync(projectId, project);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "Project Edited!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }
    }
}
