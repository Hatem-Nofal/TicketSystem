using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Server;
using Server.Data;



namespace TicketSystem.IdentityServer;

public class Startup
{
    public IConfiguration _configuration { get; }
    private readonly string _policyName = "CorsPolicy";
    private IWebHostEnvironment _environment;

    public Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
        _configuration = configuration;
        _environment = environment;
        var builder = new ConfigurationBuilder()
        .SetBasePath(environment.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();


        _configuration = builder.Build();




    }
    public void ConfigureServices(IServiceCollection services)
    {
        var defaultConnString = _configuration.GetConnectionString("DefaultConnection");

        SeedData.EnsureSeedData(defaultConnString!);
        var assembly = typeof(Program).Assembly.GetName().Name;
        services.AddDbContext<ConfigurationDbContext>(options =>
        options.UseSqlServer(defaultConnString,
                b => b.MigrationsAssembly(assembly)));
        services.AddDbContext<AspNetIdentityDbContext>(options =>
            options.UseSqlServer(defaultConnString,
                b => b.MigrationsAssembly(assembly)));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AspNetIdentityDbContext>();

        services.AddIdentityServer()
            .AddAspNetIdentity<IdentityUser>()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(assembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b =>
                b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(assembly));
            })
            .AddDeveloperSigningCredential();
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:7256";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
        services.AddControllersWithViews();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider ServiceProvider, ILoggerFactory loggerFactory)
    {
        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


    }



}


















