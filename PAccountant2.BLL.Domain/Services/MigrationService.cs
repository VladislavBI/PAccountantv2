using AutoMapper;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration;
using PAccountant2.BLL.Interfaces.Migration;
using System.Collections.Generic;
using System.Threading.Tasks;
using PAccountant2.BLL.Domain.Entities.Migration;
using PAccountant2.BLL.Domain.Entities.Migration.Currency;

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

        public async Task UpdateCurrenciesRatesAsync(IEnumerable<CurrencyMigrationViewItem> mappedCurrencies)
        {
            var migrationEntity = new MigrationEntity();
            var mappedIncome = _mapper.Map<IEnumerable<CurrencyIncomeValueObject>>(mappedCurrencies);

            await migrationEntity.MigrateCurrencies(mappedIncome, _dataService);

        }
    }
}
