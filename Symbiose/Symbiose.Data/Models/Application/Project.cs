using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data.Models.Application
{
    public enum ProjectStatus
    {
        Undefined = 0,
        Active = 1,
        Inactive = 2
    }

    public class Project : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int  CreatorId { get; set; }

        public DateTime DateCreated { get; set; }

        public ProjectStatus ProjectStatus { get; set; }
    }
}
