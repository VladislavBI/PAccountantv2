using CurrenctyRateUtil.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration;
using PAccountant2.BLL.Interfaces.Migration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PAccountant2.Host.Domain.Services
{
    public class CurrencyUpdateBackgroundService : BackgroundService
    {
        private const int DelayTime = 3600000; // 1 hour

        private IMigrationService _migrationService;

        private IRateService _rateService;

        private readonly IServiceScopeFactory _serviceScopeFactory;


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
                    (_migrationService, _rateService) = InitializeServices(scope);

                    var mappedCurrencies = await GetActualRatesAsync();

                    await _migrationService.UpdateCurrenciesRatesAsync(mappedCurrencies);
                }

                await Task.Delay(DelayTime, stoppingToken);
            }
        }

        private (IMigrationService, IRateService) InitializeServices(IServiceScope scope)
        {
            var service = scope.ServiceProvider.GetRequiredService(typeof(IMigrationService));
            var service2 = scope.ServiceProvider.GetRequiredService(typeof(IRateService));

            _migrationService = service as IMigrationService;
            _rateService = service2 as IRateService;

            return (_migrationService, _rateService);
        }

        private async Task<System.Collections.Generic.IEnumerable<CurrencyMigrationViewItem>> GetActualRatesAsync()
        {
            var currencyData = await _rateService.GetCurrentSimpleRates();
            var mappedCurrencies = currencyData.Select(cur => new CurrencyMigrationViewItem
            {
                BaseCurrency = cur.BaseCurrency,
                Currency = cur.Currency,
                Buy = cur.Buy,
                Sell = cur.Sell
            });
            return mappedCurrencies;
        }

    }
}
