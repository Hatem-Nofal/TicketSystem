
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
