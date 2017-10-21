using Microsoft.EntityFrameworkCore;
using Symbiose.Data.Models.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data
{
    public class SymbioseContext : DbContext
    {
        public SymbioseContext(DbContextOptions<SymbioseContext> dbOptions)
             : base(dbOptions)
        { }

        #region Project 

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserProject> UserProjects { get; set; }

        #endregion

        #region Tasks

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Subtask> Subtasks { get; set; }

        public DbSet<TaskComment> TaskComments { get; set; }

        #endregion

        #region Topics

        public DbSet<Topic> Topics { get; set; }

        public DbSet<TopicMessage> TopicMessages { get; set; }

        #endregion

    }
}
