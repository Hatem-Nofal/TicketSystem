using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TicketSystem.Presentation.IoC
{
    public static class PresentationServiceConfig
    {
        public static IServiceCollection PresentationServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
