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

        private ICurrencyService _currencyService;

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
                    InitializeServices(scope);

                    if (!await _migrationService.IsCurrenciesCreatedAsync())
                    {
                        var currencies = await _currencyService.GetAllCurrencies();
                        var mappedCurrencies = currencies.Currencies.Select(x => new CurrencyMigrationViewItem
                        {
                            Code = x.Code,
                            Number = x.Number,
                            FullName = x.FullName
                        });

                        await _migrationService.AddCurrenciesAsync(mappedCurrencies);
                    }

                    var mappedRates = await GetActualRatesAsync();

                    await _migrationService.UpdateCurrenciesRatesAsync(mappedRates);
                }

                await Task.Delay(DelayTime, stoppingToken);
            }
        }

        private void InitializeServices(IServiceScope scope)
        {
            var service = scope.ServiceProvider.GetRequiredService(typeof(IMigrationService));
            var service2 = scope.ServiceProvider.GetRequiredService(typeof(IRateService));
            var service3 = scope.ServiceProvider.GetRequiredService(typeof(ICurrencyService));

            _migrationService = service as IMigrationService;
            _rateService = service2 as IRateService;
            _currencyService = service3 as ICurrencyService;
        }

        private async Task<System.Collections.Generic.IEnumerable<ExchangeRatesMigrationViewItem>> GetActualRatesAsync()
        {
            var currencyData = await _rateService.GetCurrentSimpleRates();
            var mappedCurrencies = currencyData.Select(cur => new ExchangeRatesMigrationViewItem
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
