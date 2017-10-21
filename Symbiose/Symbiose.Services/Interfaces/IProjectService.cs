using Symbiose.Data.Models.Application;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symbiose.Services.Interfaces
{
    public interface IProjectService : IGenericDbService
    {
        IQueryable<Project> GetProjectsCreatedByUser(int userId);

        Task<IQueryable<Project>> GetProjectsOfUser(int userId);

        Task<IEnumerable<int>> GetUsersIdByProjectAsync(int projectId);
    }
}
