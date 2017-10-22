using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Symbiose.Services.Interfaces;
using Symbiose.Data.Models.Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symbiose.Controllers
{
    [Route("api/[controller]")]
    public class UserProjectsController : Controller
    {
        public IProjectService ProjectService { get; set; }

        public UserProjectsController(IProjectService projectService)
        {
            ProjectService = projectService;
        }

        // POST - /api/UserProjects/addNewUserProject
        [HttpPost("addNewUserProject")]
        public async Task<IActionResult> AddNewUserProject([FromBody] UserProject userProject)
        {
            try
            {
                await ProjectService.AddAsync(userProject);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "User Project Added!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }

        // POST: /api/userProjects/edit/{userProjectId}
        [HttpPost("edit/{userProjectId}")]
        public async Task<IActionResult> EditProject(int userProjectId, [FromBody] UserProject userProject)
        {
            try
            {
                await ProjectService.UpdateAsync(userProjectId, userProject);
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Successful, Text = "User Project Edited!" });
            }
            catch
            {
                return Ok(new Utils.Models.Response { Status = Utils.Models.ResponseType.Failed, Text = "Error!" });
            }
        }
    }
}
