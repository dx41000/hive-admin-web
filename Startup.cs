using hive_admin_web.Components;
using Microsoft.AspNetCore.Http.Features;
using MudBlazor.Services;

namespace hive_admin_web;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
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
        services.AddHttpClient();

        // Add Razor components
        services.AddRazorComponents()
            .AddInteractiveServerComponents();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseHttpsRedirection();
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
        });
    }
}