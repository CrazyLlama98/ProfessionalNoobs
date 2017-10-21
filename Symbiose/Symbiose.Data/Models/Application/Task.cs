using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data.Models.Application
{
    public enum TaskStatus
    {
        Undefined = 0,
        InWorking = 1,
        Completed = 2,
        Delayed = 3
    }

    class Task : Entity
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime DateEnded { get; set; }

        public int CreatedById { get; set; }

        public int AssignedToId { get; set; }

        public TaskStatus TaskStatus { get; set; }
    }
}
