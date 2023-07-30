using System.Reflection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using TrainingQuestCsharp.Server.Provider;

namespace TrainingQuestCsharp.Server
{
    public class Services
    {
        private ILogger<Services> Logger;
        private readonly IWebHostEnvironment Env;

        public Services(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        private void SetupSerilog(object? sender)
        {
            if (Log.Logger != null)
            {
                Log.Logger.Information("Logger Configuration wird geladen");
            }

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{((Env.EnvironmentName == "Production") ? "Production" : ((Env.EnvironmentName == "Staging") ? "Staging" : "Development"))}.json", optional: true)
                .AddEnvironmentVariables();

            var newLogger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentName()
                .WriteTo.Console(theme: AnsiConsoleTheme.Literate, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}][{SourceContext:l}] {Message:lj}{NewLine}{Exception}").CreateLogger();

            Log.Logger = newLogger;

            var reloadToken = Configuration.GetReloadToken();
            _ = reloadToken.RegisterChangeCallback(SetupSerilog, null);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            SetupSerilog(null);
            Log.Logger.Information("Services werden geladen");

            services.AddTransient<IDataReader, DataReader>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "SchichtberichtInterface", Version = "v1" });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Services> logger)
        {
            Logger = logger;

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrainingQuest v1");
                    c.RoutePrefix = "";
                });
            }
            else
            {
                app.UseHsts();
                //app.UseHttpsRedirection();
                app.UseStaticFiles();
            }

            app.UseRouting();
            app.UseCors(options => options.AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .SetIsOriginAllowed(origin => true));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
