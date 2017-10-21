using Symbiose.Data.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiose.Services.Interfaces
{
    public interface ITaskService : IGenericDbService
    {
        IQueryable<Data.Models.Application.Task> GetTasksByProject(int projectId);

        IQueryable<Data.Models.Application.Task> GetTasksByUser(int userId);

        IQueryable<Subtask> GetSubtasksOfTask(int taskId);

        IQueryable<Subtask> GetSubtasksByUser(int userId);

        IQueryable<Data.Models.Application.Task> GetTaskOfUser(int userId);

        IQueryable<Data.Models.Application.Task> GetTaskByStatus(Data.Models.Application.TaskStatus status);

        IQueryable<Data.Models.Application.Subtask> GetSubtaskByStatus(Data.Models.Application.TaskStatus status);
    }
}
