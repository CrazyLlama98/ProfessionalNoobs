using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Symbiose.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symbiose.Data
{
    public class UserContext : IdentityDbContext<User, UserRole, int>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}
