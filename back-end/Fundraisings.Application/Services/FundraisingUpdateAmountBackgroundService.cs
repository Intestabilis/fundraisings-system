
using Fundraisings.Application.Services.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fundraisings.Application.Services;

public class FundraisingUpdateAmountBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory  _services;
    private readonly ILogger<FundraisingUpdateAmountBackgroundService> _logger;
    // private readonly TimeSpan _updateInterval = TimeSpan.FromMinutes(10);
    private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(300);
    public FundraisingUpdateAmountBackgroundService(ILogger<FundraisingUpdateAmountBackgroundService> logger, IServiceScopeFactory services)
    {
        _services = services;
       _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Fundraising update background service started.");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _services.CreateScope();
                var updateFundraisingAmounts= 
                    scope.ServiceProvider
                        .GetRequiredService<UpdateFundraisingAmountsUseCase>();
               
                await updateFundraisingAmounts.UpdateAllAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during fundraising update.");
            }

            await Task.Delay(_updateInterval, stoppingToken);
        }

        _logger.LogInformation("Fundraising update background service stopping.");
    }
}