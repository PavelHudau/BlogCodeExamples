using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);
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

var app = builder.Build();

app.MapGet("/", () => "YARP is running!");
app.MapReverseProxy();

app.Run();