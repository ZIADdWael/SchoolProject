using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.infrustracture.DataBase;

namespace SchoolProject.infrustracture
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(
            this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(Options =>
            {
                //password setting
                Options.Password.RequiredLength = 6;
                Options.Password.RequireDigit = true;
                Options.Password.RequireLowercase = true;
                Options.Password.RequireNonAlphanumeric = true;
                Options.Password.RequireUppercase = true;
                Options.Password.RequiredUniqueChars = 1;


                //lock setting
                Options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);
                Options.Lockout.MaxFailedAccessAttempts = 5;
                Options.Lockout.AllowedForNewUsers = true;

                //User Setting
                Options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                Options.User.RequireUniqueEmail = true;
                Options.SignIn.RequireConfirmedEmail = true;


            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}