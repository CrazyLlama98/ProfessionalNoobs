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

        virtual public void CreateUserModel(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(t => t.Roles);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            CreateUserModel(ref builder);

        }
    }
}
