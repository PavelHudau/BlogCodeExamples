public class SimpleWindowsService : BackgroundService
{
    public SimpleWindowsService(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger<SimpleWindowsService>();
    }

    public ILogger Logger { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Logger.LogInformation("STOPPING SimpleWindowsService.");

        stoppingToken.Register(() => Logger.LogInformation("STARTING SimpleWindowsService."));

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }

        Logger.LogInformation("STOPPED SimpleWindowsService.");
    }
}