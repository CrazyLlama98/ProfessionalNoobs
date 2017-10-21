using Symbiose.Data.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiose.Services.Interfaces
{
    interface ITaskService : IGenericDbService
    {
        IQueryable<Data.Models.Application.Task> GetTasksByProject(int projectId);

        IQueryable<Subtask> GetSubtasksOfTask(int taskId);

        IQueryable<Data.Models.Application.Task> GetTaskOfUser(int userId);

        IQueryable<Data.Models.Application.Task> GetTaskByStatus(Data.Models.Application.TaskStatus status);

        IQueryable<Data.Models.Application.Subtask> GetSubtaskByStatus(Data.Models.Application.TaskStatus status);
    }
}
