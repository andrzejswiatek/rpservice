using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;

namespace ASW.Sensors.API
{
  /// <summary>WEB API startup</summary>
  public class Startup
  {
    private readonly string[] _commentFiles = {"ASW.Sensors.API.xml"};

    /// <inheritdoc/>
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary>Application configuration</summary>
    public IConfiguration Configuration { get; }

    /// <summary>This method gets called by the runtime. Use this method to add services to the container</summary>    
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
        .AddJsonOptions(options =>
        {
          options.SerializerSettings.Converters.Add(new StringEnumConverter());
          options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
          options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        });
      ConfigureSwagger(services);
    }

    /// <summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline</summary>    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint($"/swagger/1.0/swagger.json", "v1"); });
    }

    private void ConfigureSwagger(IServiceCollection services)
    {
      services.AddSwaggerGen(swagger =>
      {
        swagger.SwaggerDoc("1.0", new Info
        {
          Title = "Sample SENSOR API",
          Description = "Internet of things API",
          Version = "1.0"
        });

        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        foreach (var file in _commentFiles)
        {
          var commentsFile = Path.Combine(baseDirectory, file);
          swagger.IncludeXmlComments(commentsFile);
        }

        swagger.DescribeAllEnumsAsStrings();
      });
    }
  }
}