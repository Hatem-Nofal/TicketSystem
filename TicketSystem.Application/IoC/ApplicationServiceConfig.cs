using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Application.Tickets.Cmd;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Application.IoC
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection ApplicationServiceConfiguration(this IServiceCollection services, IConfiguration configuratio)
        {

            services.AddScoped<ICommand<TicketCreatedCommend, TicketId>, TicketCreatedCommendHandler>();

            return services;

        }
    }
}
