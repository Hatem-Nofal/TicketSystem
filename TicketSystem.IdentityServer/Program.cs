


using Microsoft.AspNetCore.Hosting;
using Serilog;
using Server;
using TicketSystem.IdentityServer;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("IdentityServer started ...");
        



         
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "IdentityServer failed to start ...");
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
         .ConfigureLogging(logging =>
         {
             logging.ClearProviders(); // remove any existing logging providers
         })
        .UseSerilog(SeriLogger.Configure)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureLogging((ctx, logging) =>
                {

                    logging.AddEventLog(options =>
                    {
                        options.SourceName = "TicketSystem";
                    });
                });
            });
}


