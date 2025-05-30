﻿using hive_admin_web.Components;
using hive_admin_web.Models;
using hive_admin_web.Models.AppSettings;
using hive_admin_web.Services;
using hive_admin_web.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using MudBlazor.Services;

namespace hive_admin_web;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        var config = new Config();
        Configuration.Bind("Config", config);
        services.AddSingleton(config);

        services.AddTransient<IAssetService, AssetService>();
        services.AddTransient<IAssetVariantService, AssetVariantService>();
        services.AddTransient<IAssetVariantViewService, AssetVariantViewService>();
        services.AddTransient<IImageDownloaderService, ImageDownloaderService>();
        services.AddTransient<IProductariantViewService, ProductariantViewService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IProductVariantService, ProductVariantService>();
        services.AddTransient<IStoreService, StoreService>();
        services.AddSingleton<AppState>();

        
        // Configure SignalR
        services.AddSignalR(options =>
        {
            options.EnableDetailedErrors = true;
            options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10 MB
        });

        // Configure form options
        services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10 MB
        });

        // Configure IIS request body size
        services.Configure<IISServerOptions>(options =>
        {
            options.MaxRequestBodySize = 10 * 1024 * 1024; // 10 MB
        });

        // Add MudBlazor services
        services.AddMudServices();

        // Register HttpClient
        services.AddHttpClient("HiveCore", client =>
        {
            client.BaseAddress = new Uri(config.BaseUrl);
            //client.Timeout = TimeSpan.FromMinutes(2);
            client.Timeout = Timeout.InfiniteTimeSpan;
        });

        // Add Razor components
        services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        services.AddControllers(); 
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        //app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // If using authentication/authorization, include these first:
        // app.UseAuthentication();
        // app.UseAuthorization();

        // ✅ Add Antiforgery middleware *after* UseRouting and before UseEndpoints
        app.UseAntiforgery();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            endpoints.MapGet("/health", async context =>
            {
                await context.Response.WriteAsync("Healthy");
            });
            
            endpoints.MapControllers();
        });
    }
}