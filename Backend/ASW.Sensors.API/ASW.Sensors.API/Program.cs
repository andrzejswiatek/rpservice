using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ASW.Sensors.API
{
  /// <summary>Program entry point class</summary>
  public class Program
  {
    /// <summary> Program entry point method</summary>
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    /// <summary>Builds web host</summary>
    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
      var baseDirectory = Directory.GetCurrentDirectory();

      Console.WriteLine($"Starting application using base directory: {baseDirectory}.");

      return WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseKestrel()
        .ConfigureLogging((context, loggingBuilder) =>
        {
          var configuration = context.Configuration.GetSection("Logging");
          if (configuration != null)
          {
            loggingBuilder.AddFile(configuration);
          }
          else
          {
            Console.WriteLine("Could not activate logging! Please check appsettings.json file.");
          }
        })
        .UseContentRoot(baseDirectory);
    }
  }
}