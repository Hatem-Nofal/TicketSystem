using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Infrastructure.IoC
{
    public static class InfrastructureServiceConfig
    {
        public static IServiceCollection InfrastructureServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
