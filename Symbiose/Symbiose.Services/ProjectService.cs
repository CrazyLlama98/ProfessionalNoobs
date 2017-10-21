using Symbiose.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Symbiose.Data;
using Symbiose.Data.Models.Application;
using System.Threading.Tasks;
using System.Linq;
using Symbiose.Data.Models.Account;

namespace Symbiose.Services
{
    public class ProjectService : GenericDbService, IProjectService
    {
        public ProjectService(SymbioseContext context)
            : base(context)
        { }

        public IQueryable<Project> GetProjectsCreatedByUser(int userId)
        {
            return Context.Set<Project>().Where(p => p.CreatorId == userId);
        }

        public async Task<IQueryable<Project>> GetProjectsOfUser(int userId)
        {
            List<int> projectsId = await Context.Set<UserProject>().Where(up => up.UserId == userId).Select(up => up.ProjectId).ToListAsync();
            return Context.Set<Project>().Where(p => projectsId.Contains(p.Id));
        }

        public async Task<IEnumerable<int>> GetUsersIdByProjectAsync(int projectId)
        {
            return await Context.Set<UserProject>().Where(up => up.ProjectId == projectId).Select(up => up.UserId).ToListAsync();
        }
    }
}
