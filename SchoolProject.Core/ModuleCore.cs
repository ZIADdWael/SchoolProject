using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviours;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCore
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {

            //Configratiom  of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configratiom  of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;


        }
    }
}
