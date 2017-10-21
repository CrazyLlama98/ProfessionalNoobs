using Microsoft.AspNetCore.Identity;

namespace Symbiose.Data.Models.Account
{
    public class UserRole : IdentityRole<int>
    {
        public int ProjectId { get; set; }
    }
}
