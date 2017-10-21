using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data.Models.Application
{
    public class Subtask : Entity
    {
        public int DerivedFromId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime DateEnded { get; set; }

        public int CreatedById { get; set; }

        public int AssigneeId { get; set; }

        public TaskStatus TaskStatus { get; set; }
    }
}
