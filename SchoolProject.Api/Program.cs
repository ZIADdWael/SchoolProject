
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.MiddleWare;
using SchoolProject.infrustracture;
using SchoolProject.infrustracture.DataBase;
using SchoolProject.Service;
using System.Globalization;

namespace SchoolProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DataBase Connection

            builder.Services.AddDbContext<AppDbContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"))
            );

            //Dependency Injection

            builder.Services.AddInfructractureDependencies().AddCoreDependencies().AddModuleServiceDependencies();


            #region Localization 
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
    };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            #endregion

            #region AddCors
            var Cors = "_myAllowSpecificOrigins";

            builder.Services.AddCors(option => {
                option.AddPolicy(name: Cors,
    policy => {
                           policy.AllowAnyHeader();
                           policy.AllowAnyMethod();
                           policy.AllowAnyOrigin();
                           

        }

                    );
            
            });
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region Localization Middleware
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            #endregion

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors(Cors);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
