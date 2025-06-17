using hive_admin_web.Components;
using hive_admin_web.Models;
using hive_admin_web.Models.AppSettings;
using hive_admin_web.Services;
using hive_admin_web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
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
        services.AddTransient<AccessTokenService>();
        services.AddHttpContextAccessor();
        
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
        })
        .AddHttpMessageHandler<AccessTokenService>();

        // Add Razor components
        services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        services.AddControllers(); 
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                //
                options.MetadataAddress = "https://cognito-idp.eu-west-2.amazonaws.com/eu-west-2_pvR2avA9O/.well-known/openid-configuration";
                options.ClientId = "3ukppiajum9dksjjkrb9oqf39a";
                options.ClientSecret = "1nfdp48of878toicdm1qi16mm35j6mng7bg3jr0i1iemn09rt1tl";
                options.Authority = "https://cognito-idp.eu-west-2.amazonaws.com/eu-west-2_pvR2avA9O";
                options.CallbackPath = "/signin-oidc";
                options.ResponseType = OpenIdConnectResponseType.Code;
                options.SignedOutCallbackPath = "/signedout-oidc";
                options.UseTokenLifetime = true;

                options.Scope.Clear(); // Optional: start fresh
                options.Scope.Add("openid"); // ✅ required
                options.Scope.Add("email");  // ✅ match what you enable in Cognito
                //options.Scope.Add("profile"); // ✅ optional
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true
                };
                options.SaveTokens = true;
                options.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProvider = context =>
                    {
                        var request = context.Request;

                        // var forwardedProto = request.Headers["X-Forwarded-Proto"].ToString();
                        // if (forwardedProto == "https")
                        // {
                            var uriBuilder = new UriBuilder(context.ProtocolMessage.RedirectUri)
                            {
                                Scheme = "https",
                                Port = -1 // remove the port if it's not needed
                            };
                            context.ProtocolMessage.RedirectUri = uriBuilder.ToString();
                        // }

                        return Task.CompletedTask;
                    }
                };

            });

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedFor;
         
        });
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // if (!env.IsDevelopment())
        // {
        //     app.UseExceptionHandler("/Error", createScopeForErrors: true);
        //     app.UseHsts();
        // }
        // else
        // {
            app.UseDeveloperExceptionPage();
       // }

        //app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedFor,
            // Optionally restrict trusted networks
            // KnownNetworks = { new IPNetwork(IPAddress.Parse("172.31.0.0"), 16) }, // Example VPC
            // KnownProxies = { IPAddress.Parse("your-alb-ip") } 
        });
        
        app.UseRouting();

        // If using authentication/authorization, include these first:
        app.UseAuthentication();
        app.UseAuthorization();

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