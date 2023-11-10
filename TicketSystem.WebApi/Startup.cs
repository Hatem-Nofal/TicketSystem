using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
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
            var presentationAssembly = Presentation.AssemblyReferenceHelper.GetAssembly();
            services.AddControllers().AddApplicationPart(presentationAssembly);

            //Configure MediatR from  Application
            var applicationAsAmbly = Application.AssemblyReferenceHelper.GetAssembly();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, applicationAsAmbly);
            });

            //DependencyInjectionConfiguration
            services.AddDependencyInjectionConfiguration(_configuration);

            // Swagger Config
            services.AddSwaggerConfigurationIdentityServer(_configuration);

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
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}
