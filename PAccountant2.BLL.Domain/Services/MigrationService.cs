using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Migration;
using PAccountant2.BLL.Domain.Entities.Migration.Currency;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration;
using PAccountant2.BLL.Interfaces.Migration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;

namespace PAccountant2.BLL.Domain.Services
{
    public class MigrationService : IMigrationService
    {
        private readonly IMigrationDataService _dataService;
        private readonly IMapper _mapper;

        public MigrationService(IMigrationDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<bool> IsCurrenciesCreatedAsync()
            => await _dataService.IsCurrenciesCreatedAsync();



        public async Task AddCurrenciesAsync(IEnumerable<CurrencyMigrationViewItem> mappedCurrencies)
        {
            var dbMappedCurrencies = mappedCurrencies.Select(x => new CurrencyMigrationDataItem
            {
                Code = x.Code,
                FullName = x.FullName,
                Number = x.Number
            });

            await _dataService.AddCurrenciesAsync(dbMappedCurrencies);
        }

        public async Task UpdateCurrenciesRatesAsync(IEnumerable<ExchangeRatesMigrationViewItem> mappedCurrencies)
        {
            var migrationEntity = new MigrationEntity();
            var mappedIncome = _mapper.Map<IEnumerable<CurrencyIncomeValueObject>>(mappedCurrencies);

            await migrationEntity.MigrateCurrencies(mappedIncome, _dataService);

        }
    }
}
