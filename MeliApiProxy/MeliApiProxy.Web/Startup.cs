using MeliApiProxy.Infrastructure.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MeliApiProxy.Domain.Interfaces;
using MeliApiProxy.Domain.Services;
using MeliApiProxy.Web.Models.Extensions;
using MeliApiProxy.Domain.Entities.Log;
using MeliApiProxy.Web.Middleware;

namespace MeliApiProxy.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add reverse proxy
        var proxyBuilder = services.AddReverseProxy();
        proxyBuilder.LoadFromConfig(Configuration.GetSection("ReverseProxy"));

        services.AddScoped<ILogsRepository, LogsRepository>();
        services.AddScoped<IRestrictionsRepository, RestrictionsRepository>();
        services.AddScoped<IRequestLogService, RequestLogService>();
        services.AddScoped<IRestrictionsService, RestrictionsService>();

        var dbConnectionString = Configuration.GetConnectionString("LogAndRestrictionsDbConnectionString");
        services.AddDbContext<LogAndRestrictionsDbContext>(options => options
            .UseMySql(
                dbConnectionString,
                ServerVersion.AutoDetect(dbConnectionString)
            )
        );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request 
    // pipeline that handles requests
    public void Configure(
        IApplicationBuilder app, 
        IWebHostEnvironment env, 
        IRequestLogService requestLogService)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        // Enable endpoint routing, required for the reverse proxy
        app.UseRouting();
        // Register the reverse proxy routes
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapReverseProxy(proxyPipeline =>
            {
                proxyPipeline.UseMiddleware<LoggingMiddleware>();
                proxyPipeline.UseMiddleware<RestrictionsMiddleware>();
                proxyPipeline.UseSessionAffinity();
                proxyPipeline.UseLoadBalancing();
                proxyPipeline.UsePassiveHealthChecks();
            });
        });
    }
}