using Microsoft.AspNetCore.Identity;

namespace Symbiose.Data.Models.Account
{
    public class UserRole : IdentityRole<int>
    {
        public UserRole() : base() { }
        public UserRole(string roleName) : base(roleName) { }
    }
}
