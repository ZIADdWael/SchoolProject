using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infrustracture.Abstract;
using SchoolProject.infrustracture.InfrastructureBase;
using SchoolProject.infrustracture.Repo;

namespace SchoolProject.infrustracture
{
    public static class ModuleInfrustracture
    {
        public static IServiceCollection AddInfructractureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IinstructorRepo, InstructorRepo>();
            services.AddScoped<ISubjectRepo, SubjectRepo>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
