using Symbiose.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Symbiose.Data;
using Symbiose.Data.Models.Application;
using System.Linq;

namespace Symbiose.Services
{
    public class TaskService : GenericDbService, ITaskService
    {
        public TaskService(SymbioseContext context) : base(context)
        { }

        public IQueryable<Subtask> GetSubtasksOfTask(int taskId)
        {
            return Context.Set<Subtask>().Where(st => st.ParentId == taskId);
        }

        public IQueryable<Task> GetTaskOfUser(int userId)
        {
            return Context.Set<Task>().Where(t => t.AssigneeId == userId);
        }

        public IQueryable<Task> GetTasksByProject(int projectId)
        {
            return Context.Set<Task>().Where(t => t.ProjectId == projectId);
        }

        public IQueryable<Task> GetTasksByUser(int userId)
        {
            return Context.Set<Task>().Where(t => t.AssigneeId == userId);
        }

        public IQueryable<Task> GetTaskByStatus(TaskStatus status)
        {
            return Context.Set<Task>().Where(t => t.TaskStatus == status);
        }

        public IQueryable<Subtask> GetSubtaskByStatus(TaskStatus status)
        {
            return Context.Set<Subtask>().Where(st => st.TaskStatus == status);
        }
    }
}
