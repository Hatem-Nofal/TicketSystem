using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Domain.Common.Interfaces;
namespace TicketSystem.Application.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<TicketSystemDbContext>(
                 options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<TicketSystemDbContext>();


    }
}

