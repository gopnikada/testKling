using Serilog;

namespace TrainingQuestCsharp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = CreateHostBuilder(args)
                .UseSerilog()
                .Build();

            Log.Logger.Information("Anwendung gestartet");

            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Services>();
                });
    }
}