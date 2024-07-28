using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

bool isRunningAsWindowsService = Environment.GetEnvironmentVariable("RUNNING_AS") == "WindowsService";

if (isRunningAsWindowsService)
{
    // Point configuration and content root to a folder
    // where application binaries and files are located.
    var rootFolder = AppContext.BaseDirectory;
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
                      Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ??
                      string.Empty;
    var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(rootFolder)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .AddCommandLine(args);

    builder.WebHost
        .UseConfiguration(configurationBuilder.Build())
        .UseContentRoot(rootFolder);
}

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(builderCtx =>
    {
        // Add new header
        builderCtx.AddRequestHeader("new-header", "new-header-value");
        builderCtx.AddRequestTransform(transformCtx =>
        {
            if (transformCtx.ProxyRequest?.Content != null)
            {
                // Update header-to-update header
                transformCtx.ProxyRequest.Content.Headers.Remove("header-to-update");
                transformCtx.ProxyRequest.Content.Headers.Add("header-to-update", "value");
            }
            return ValueTask.CompletedTask;
        });
    });

if (isRunningAsWindowsService)
{
    // Add Windows Service
    builder.Services.AddWindowsService();
    builder.Services.AddHostedService<SimpleWindowsService>();
}

var app = builder.Build();

app.MapGet("/", () => "YARP is running!");
app.MapReverseProxy();


app.Run();