using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Application.Interfaces.Base;
using TicketSystem.Infrastructure.Data.Base;
namespace TicketSystem.Infrastructure.IoC
{
    public static class InfrastructureServiceConfig
    {
        public static IServiceCollection InfrastructureServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
