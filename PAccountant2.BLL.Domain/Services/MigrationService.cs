using AutoMapper;
using CurrenctyRateUtil.Services;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration;
using PAccountant2.BLL.Interfaces.Migration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Domain.Services
{
    public class MigrationService : IMigrationService
    {
        private readonly IMigrationDataService _dataService;
        private readonly IMapper _mapper;
        private readonly IRateService _rateService;

        public MigrationService(IMigrationDataService dataService, IMapper mapper, IRateService rateService)
        {
            _dataService = dataService;
            _mapper = mapper;
            _rateService = rateService;
        }

        public async Task UpdateCurrenciesRatesAsync()
        {
            var currencyData = await _rateService.GetCurrentSimpleRates();
            var mappedCurrencies = currencyData.Select(cur => new CurrencyMigrationViewItem
            {
                BaseCurrency = cur.BaseCurrency,
                Currency = cur.Currency,
                Buy = cur.Buy,
                Sell = cur.Sell
            });

            var dbData = _mapper.Map<IEnumerable<CurrencyMigrationDataItem>>(mappedCurrencies);

            await _dataService.UpdateCurrenciesRatesAsync(dbData);
        }
    }
}
