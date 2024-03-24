using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Application.Tickets.Cmd;

namespace TicketSystem.Application.IoC
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection ApplicationServiceConfiguration(this IServiceCollection services, IConfiguration configuratio)
        {

            services.AddScoped<IRequestHandler<TicketCreatedCommend, Unit>, TicketCreatedCommendHandler>();

            return services;

        }
    }
}
