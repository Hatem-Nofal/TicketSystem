


using Serilog;
using TicketSystem.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Transaction Api started ...");
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Transaction Api failed to start ...");
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