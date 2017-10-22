using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Symbiose.Data.Models.Account;
using Microsoft.AspNetCore.Authorization;
using static Symbiose.Utils.Models;
using Symbiose.ViewModels;
using Symbiose.Extensions;
using Microsoft.AspNetCore.Http;
using Symbiose.Services;
using Symbiose.Services.Interfaces;
using Symbiose.Data.Models.Application;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symbiose.Accounts
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly UserManager<User> UserManager;
        private readonly SignInManager<User> SignInManager;
        private readonly RoleManager<UserRole> RoleManager;
        private readonly IProjectService ProjectService;

        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<UserRole> roleManager, IProjectService projectService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
            ProjectService = projectService;
        }

        [HttpPost("identity")]
        public IActionResult Identity()
        {
            try
            {
                var account = UserManager.GetUserAsync(User).Result;
                if (account != null)
                {
                    var roleNames = UserManager.GetRolesAsync(account).Result;
                    return Ok(new User
                    {
                        UserName = account.UserName,
                        Email = account.Email,
                        Roles = ProjectService.Set<UserProject>().Where(up => roleNames.Any(r => r == up.UserRoleName))
                        .Select(up => new ProjectRole { ProjectId = up.ProjectId, RoleName = up.UserRoleName }).ToListAsync().Result,
                        Id = account.Id
                    });
                }
                return Unauthorized();
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpPost("logIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody]SignIn model)
        {
            try
            {
                Response response = new Response { Status = ResponseType.Failed };
                if (ModelState.IsValid)
                {
                    var result = await SignInManager.PasswordEmailSignInAsync(model.Email, model.Password, true, false, UserManager);
                    if (result.Succeeded)
                    {
                        response.Status = ResponseType.Successful;
                    }
                    else
                    {
                        response.Text = "Invalid Credentials!";
                    }
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logOut")]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                await SignInManager.SignOutAsync();
                return Ok(new Response { Status = ResponseType.Successful });
            }
            catch (Exception e)
            {
                return Ok(new Response { Status = ResponseType.Failed, Text = e.ToString() });
            }
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]Register model)
        {
            try
            {
                var existUser = UserManager.FindByNameAsync(model.UserName).Result;
                if (existUser != null)
                    return Ok(new Response { Status = ResponseType.Failed, Text = "Username already exist!" });
                var newUser = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true
                };
                var userCreateResp = await UserManager.CreateAsync(newUser, model.Password);
                if (!userCreateResp.Succeeded)
                    return Ok(new Response { Status = ResponseType.Failed, Text = userCreateResp.Errors.FirstOrDefault().Description });
                return Ok(new Response { Status = ResponseType.Successful });
            }
            catch (Exception e)
            {
                return Ok(new Response { Status = ResponseType.Failed, Text = e.ToString() });
            }
        }

        [HttpPost("addToRole")]
        public async Task<IActionResult> AddUserToRole([FromBody] UserRoleRequest userRoleRequest)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(userRoleRequest.UserId.ToString());
                if (user == null)
                    return NotFound();
                await UserManager.AddToRoleAsync(user, userRoleRequest.RoleName);
                if (ProjectService.Set<UserProject>().Where(up => up.ProjectId == userRoleRequest.ProjectId &&
                    up.UserRoleName == userRoleRequest.RoleName && up.UserId == userRoleRequest.UserId).Count() > 0)
                    return Ok(new Response { Status = ResponseType.Failed, Text = "User already assigned to this project!" });
                await ProjectService.AddAsync(new UserProject
                {
                    ProjectId = userRoleRequest.ProjectId,
                    UserRoleName = userRoleRequest.RoleName,
                    UserId = userRoleRequest.UserId
                });
                return Ok(new Response { Status = ResponseType.Successful, Text = "User added to role!" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
