using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Symbiose.Data.Models.Account
{
    public class User : IdentityUser<int>
    {
        public IEnumerable<ProjectRole> Roles { get; set; }
    }
}
