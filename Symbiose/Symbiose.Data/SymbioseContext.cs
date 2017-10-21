using Microsoft.EntityFrameworkCore;
using Symbiose.Data.Models.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data
{
    class SymbioseContext : DbContext
    {
       public SymbioseContext(DbContextOptions<SymbioseContext> dbOptions)
            : base(dbOptions)
        {
            
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Subtask> Subtasks { get; set; }
    }
}
