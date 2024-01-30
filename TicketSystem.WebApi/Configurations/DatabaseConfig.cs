using Microsoft.EntityFrameworkCore;
using TicketSystem.Infrastructure.Context;
using TicketSystem.Presentation.Interceptors;
namespace TicketSystem.Application.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        //services.AddSingleton<DomainEventInterceptor>();
        services.AddSingleton<OutboxMessageInterceptor>();

        services.AddDbContext<TicketSystemDbContext>(
                (sp, options) =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                   .AddInterceptors(
                        //sp.GetService<DomainEventInterceptor>(), 
                        sp.GetService<OutboxMessageInterceptor>());
                });
        services.AddScoped<TicketSystemDbContext>();


    }
}

