using Microsoft.OpenApi.Models;

namespace TicketSystem.WebApi.Configurations
{
    internal static class SwashbuckleSchemaHelper
    {
        private static readonly Dictionary<string, int> _schemaNameRepetition = new Dictionary<string, int>();

        public static string GetSchemaId(Type type)
        {
            string id = type.Name;

            if (!_schemaNameRepetition.ContainsKey(id))
                _schemaNameRepetition.Add(id, 0);

            int count = (_schemaNameRepetition[id] + 1);
            _schemaNameRepetition[id] = count;

            return type.Name + (count > 1 ? count.ToString() : "");
        }
    }
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfigurationIdentityServer(this IServiceCollection services, IConfiguration _configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => SwashbuckleSchemaHelper.GetSchemaId(type));
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TicketSystem.WebAPI", Version = "v1" });


            });
        }
        public static void AddSwaggerConfigurationJWT(this IServiceCollection services, IConfiguration _configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.CustomSchemaIds(type => SwashbuckleSchemaHelper.GetSchemaId(type));
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TicketSystem Project",
                    Description = "TicketSystem API Swagger surface",
                    Contact = new OpenApiContact { Name = "Eduardo Pires", Email = "contato@eduardopires.net.br", Url = new Uri("http://www.eduardopires.net.br") },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/EduardoPires/MerchantProject/blob/master/LICENSE") }
                });


            });
        }
        public static void UseSwaggerSetupJWT(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

        public static void UseSwaggerSetupIdentityServer(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration _configuration)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            app.UseSwagger();
            if ((env.IsProduction() || env.EnvironmentName == "DebugProduction" || env.EnvironmentName == "Development"))
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketSystem.WebAPI v1");



                });
            }
            else
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketSystem.WebAPI v1");

                });
            }

        }
    }
}
