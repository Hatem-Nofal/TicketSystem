using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TicketSystem.Application.IoC
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection ApplicationServiceConfiguration(this IServiceCollection services, IConfiguration configuratio)
        {
            ////AutoMapper
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Application
            // services.AddMediatR(assembly);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;

        }
    }
}
