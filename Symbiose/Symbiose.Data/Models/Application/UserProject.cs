using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data.Models.Application
{
    public class UserProject : Entity
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
