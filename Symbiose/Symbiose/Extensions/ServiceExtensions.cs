using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Symbiose.Data;
using Symbiose.Data.Models.Account;
using Symbiose.Services;
using Symbiose.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Symbiose.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer("Server=(local);Initial Catalog=SymbioseUsers;Trusted_Connection=Yes;");
            });
            services.AddIdentity<User, UserRole>()
                .AddEntityFrameworkStores<UserContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
            return services;
        }

        public static IServiceCollection AddCookieOptions(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromHours(3);
                options.Events.OnRedirectToLogin = context => {
                    context.Response.Clear();
                    context.Response.StatusCode = 401;
                    return Task.FromResult(0);
                };
            });
            return services;
        }

        public static IServiceCollection AddDbServices(this IServiceCollection services)
        {
            services.AddDbContext<SymbioseContext>(options => options.UseSqlServer("Server=(local);Initial Catalog=Symbiose;Trusted_Connection=Yes;"));
            services.AddTransient<IProjectService, ProjectService>()
                .AddTransient<ITaskService, TaskService>()
                .AddTransient<ITopicService, TopicService>();
            return services;
        }
    }
}
