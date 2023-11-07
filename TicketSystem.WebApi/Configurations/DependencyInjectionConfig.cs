using TicketSystem.Application.IoC;
using TicketSystem.Infrastructure.IoC;
using TicketSystem.Presentation.IoC;

namespace TicketSystem.WebApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            ApplicationServiceConfig.ApplicationServiceConfiguration(services);
            InfrastructureServiceConfig.InfrastructureServiceConfiguration(services, configuration);
            PresentationServiceConfig.PresentationServiceConfiguration(services, configuration);
        }
    }
}
