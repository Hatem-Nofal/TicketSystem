using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketSystem.Application.Tickets.Cmd;

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
            services.AddScoped<IRequestHandler<TicketCreatedCommend>, TicketCreatedCommendHandler>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;

        }
    }
}
