
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Presentation.Interceptors;

namespace TicketSystem.Presentation.IoC
{
    public static class PresentationServiceConfig
    {
        public static IServiceCollection PresentationServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DomainEventInterceptor>();
            return services;
        }
    }
}
