using MailBox.Web.Providers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MailBox.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILoggerManager>();
            logger.LogInformation("Starting the Host");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                     webBuilder.UseIIS();
                 });

        //.ConfigureLogging((context, logging) =>
        //{
        //    logging.ClearProviders();
        //    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
        //    logging.AddDebug();
        //    logging.AddConsole();
        //})

        //.ConfigureLogging(builder =>
        //{
        //    builder.Configuration.GetSection("log4net.config");
        //    builder.AddLog4Net("log4net.config");
        //});
    }
}
