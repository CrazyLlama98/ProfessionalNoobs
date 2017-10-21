using Microsoft.AspNetCore.Identity;
using Symbiose.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symbiose.Extensions
{
    public static class AccountExtensions
    {


        public static async Task<SignInResult> PasswordEmailSignInAsync(this SignInManager<User> signInManager, string email, string password, bool isPersistent, bool shouldLockout, UserManager<User> userManager)
        {
            var user = await userManager.FindByEmailAsync(email);
            return await signInManager.PasswordSignInAsync(user.UserName, password, isPersistent, shouldLockout);
        }
    }
}
