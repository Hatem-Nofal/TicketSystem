using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Presentation.BackgroundJobs;

namespace TicketSystem.Presentation.IoC
{
    public static class PresentationServiceConfig
    {
        public static IServiceCollection PresentationServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IprocessOutboxMessagesJob, ProcessOutboxMessagesJob>();

            return services;
        }
    }
}
