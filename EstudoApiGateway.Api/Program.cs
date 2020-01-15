using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace EstudoApiGateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                //.UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(
                    (context, config) =>
                    {
                        var env = context.HostingEnvironment;

                        config.Sources.Clear();
                        config.SetBasePath(env.ContentRootPath);
                        config.AddJsonFile("appsettings.json", true, true);
                        config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
                        config.AddJsonFile("configuration.json");
                        config.AddEnvironmentVariables();
                    })
                .UseStartup<Startup>();
    }
}
