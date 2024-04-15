using MediatR;
using Quartz;
using TicketSystem.Application.Configurations;
using TicketSystem.Infrastructure.BackgroundJobs;
using TicketSystem.WebApi.Configurations;

namespace TicketSystem.WebApi
{

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
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();
                });
            });

            //Configure Controllers from  Presentation
            services.AddControllers().AddApplicationPart(Presentation.AssemblyReferenceHelper.Assembly);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Configure MediatR from  Application
            services.AddMediatR(Application.AssemblyReferenceHelper.Assembly);

            services.AddControllersWithViews();

            //DependencyInjectionConfiguration
            services.AddDependencyInjectionConfiguration(_configuration);

            // Swagger Config
            services.AddSwaggerConfigurationIdentityServer(_configuration);
            services.AddDatabaseConfiguration(_configuration);

            services.AddQuartz(configure =>
            {
                var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));

                configure
                    .AddJob<ProcessOutboxMessagesJob>(jobKey)
                    .AddTrigger(
                        trigger =>
                            trigger.ForJob(jobKey)
                                .WithSimpleSchedule(
                                    schedule =>
                                        schedule.WithIntervalInSeconds(10)
                                            .RepeatForever()));

                configure.UseMicrosoftDependencyInjectionJobFactory();
            });

            services.AddQuartzHostedService();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider ServiceProvider, ILoggerFactory loggerFactory)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}
