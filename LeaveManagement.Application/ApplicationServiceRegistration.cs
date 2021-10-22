using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRLeaveManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // Note: We don't do this because we need to write the line like this for every MappingProfile we have,
            // assuming we gonna have multiple MappingProfile
            // services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
