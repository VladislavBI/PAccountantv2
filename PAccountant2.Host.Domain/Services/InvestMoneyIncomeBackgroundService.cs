using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PAccountant2.BLL.Interfaces.Investment;
using System.Threading;
using System.Threading.Tasks;

namespace PAccountant2.Host.Domain.Services
{
    public class InvestMoneyIncomeBackgroundService : BackgroundService
    {
        private const int DelayTime = 86400000; // 1 day

        private IInvestmentService _investmentService;

        private readonly IServiceScopeFactory _serviceScopeFactory;


        public InvestMoneyIncomeBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    _investmentService = InitializeServices(scope);

                    await _investmentService.AddMoneyAutoAsync();
                }

                await Task.Delay(DelayTime, stoppingToken);
            }
        }

        private IInvestmentService InitializeServices(IServiceScope scope)
        {
            var service = scope.ServiceProvider.GetRequiredService(typeof(IInvestmentService));

            // ReSharper disable once SuspiciousTypeConversion.Global
            var invService = service as IInvestmentService;

            return invService;
        }

    }
}
