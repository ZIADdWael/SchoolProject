using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infrustracture.Abstract;
using SchoolProject.infrustracture.Repo;
using SchoolProject.Service.Abstract;
using SchoolProject.Service.Implementation;

namespace SchoolProject.Service
{
    public static class ModuleService
    {
        public static IServiceCollection AddModuleServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
