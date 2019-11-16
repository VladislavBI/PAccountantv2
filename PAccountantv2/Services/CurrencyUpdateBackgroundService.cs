using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PAccountant2.BLL.Interfaces.Migration;

namespace PAccountantv2.Host.Api.Services
{
    public class CurrencyUpdateBackgroundService: BackgroundService
    {
        private const int DelayTime = 3600000; // 1 hour

        private IMigrationService _migrationService;

        private IServiceScopeFactory _serviceScopeFactory;


        public CurrencyUpdateBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService(typeof(IMigrationService));
                    _migrationService = service as IMigrationService;

                    await _migrationService.UpdateCurrenciesRatesAsync();
                }

                await Task.Delay(DelayTime, stoppingToken);
            }
        }
    }
}
