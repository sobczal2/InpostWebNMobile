using Sobczal.InPost.Application.Services;

namespace Sobczal.InPost.Api.Tasks;

public class BumpPackageStatusHostedService : IHostedService, IDisposable
{
    private readonly ILogger<BumpPackageStatusHostedService> _logger;
    private readonly IBumpPackageStepService _bumpPackageStepService;
    private Timer? _timer = null;

    public BumpPackageStatusHostedService(ILogger<BumpPackageStatusHostedService> logger, IBumpPackageStepService bumpPackageStepService)
    {
        _logger = logger;
        _bumpPackageStepService = bumpPackageStepService;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Bumping package status service is starting");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromMinutes(5));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        _bumpPackageStepService.BumpPackageStep(0.5).Wait();
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Bumping package status service is stopping");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}