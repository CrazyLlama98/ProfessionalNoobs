using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symbiose.ViewModels
{
    public class UserRoleRequest
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public int ProjectId { get; set; }
    }
}
