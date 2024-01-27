using Microsoft.EntityFrameworkCore;
using TicketSystem.Infrastructure.Context;
using TicketSystem.Presentation.Interceptors;
namespace TicketSystem.Application.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<TicketSystemDbContext>(
                (sp, options) =>
                {
                    var domainEventInterceptors = sp.GetService<DomainEventInterceptor>();


                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .AddInterceptors(domainEventInterceptors);
                });
        services.AddScoped<TicketSystemDbContext>();


    }
}

