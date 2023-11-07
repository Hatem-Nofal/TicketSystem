using System;
using System.IO;

 
    public static class SeriLogger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
           (context, configuration) =>
           {

               var seqInfoUri = context.Configuration.GetValue<string>("SeqConfiguration:InfoUri");
               var seqErrorUri = context.Configuration.GetValue<string>("SeqConfiguration:ErrorUri");

               var path = Directory.GetCurrentDirectory();

               #region  Log

               configuration
                    .Enrich.FromLogContext()
                    .MinimumLevel.Information()
                    .Enrich.WithMachineName()
                    .Enrich.WithSensitiveDataMasking(
                     options =>
                     {
                         options.MaskProperties.AddRange(new List<string> { "cardNumber", "cardCvv", "password" });
                         // options.ExcludeProperties.AddRange(new List<string> { "cardNumber", "cardCvv", "password" });
                         //options.MaskingOperators.Clear();
                         //options.MaskValue = "****";
                         options.MaskingOperators = new List<IMaskingOperator>
                         {
                             new CreditCardMaskingOperator(false),
                             new CvvMaskingOperator(),
                             //new PasswordMaskingOperator()

						 };
                     })
                    .WriteTo.Async(a => a.File($"{path}\\Logs\\Log-{DateTime.UtcNow:yyyyMMdd}.txt", outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] ({SourceContext}) {Message}{NewLine}{Exception}"))

                     .WriteTo.Async(a => a.Logger(lc => lc
                     .Filter.ByExcluding(evt => evt.Level == LogEventLevel.Error)
                     .Filter.ByExcluding(Matching.FromSource("Microsoft"))
                     .Filter.ByExcluding(Matching.FromSource("Swashbuckle.AspNetCore.Swagger"))

                     .WriteTo.Async(a => a.Seq(seqInfoUri))))

                       .WriteTo.Async(a => a.Logger(lc => lc
                       .Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Error)
                       .Filter.ByExcluding(Matching.FromSource("Microsoft"))
                      .Filter.ByExcluding(Matching.FromSource("Swashbuckle.AspNetCore.Swagger"))

                      .WriteTo.Async(a => a.Seq(seqInfoUri))))

                       .WriteTo.Async(a => a.Logger(lc => lc
                       .Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Error)
                       .Filter.ByExcluding(Matching.FromSource("Microsoft"))
                      .Filter.ByExcluding(Matching.FromSource("Ocelot.Authentication.Middleware.AuthenticationMiddleware"))

                       .WriteTo.Async(a => a.Seq(seqErrorUri))))

                    //.WriteTo.Seq(seqInfoUri, restrictedToMinimumLevel: LogEventLevel.Information)
                    //.WriteTo.Seq(seqErrorUri, restrictedToMinimumLevel: LogEventLevel.Error)
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                    .ReadFrom.Configuration(context.Configuration);

               #endregion





           };



    }

 
