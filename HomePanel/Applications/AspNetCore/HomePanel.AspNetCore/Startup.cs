using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using HomePanel.Common.Extensions;
using System.Reflection;
using System.Diagnostics;

namespace HomePanel.AspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = CreateSeriLogger(configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        private ILogger CreateSeriLogger(IConfiguration configuration) =>
            new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("AssemblyFileVersion", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .WriteTo.Seq(configuration["SeriLog:SeqUrl"].IsNullOrWhiteSpace() ? "http://localhost:5341/" : configuration["SeriLog:SeqUrl"], restrictedToMinimumLevel: LogEventLevel.Debug)
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Verbose)
                .CreateLogger();
    }
}
