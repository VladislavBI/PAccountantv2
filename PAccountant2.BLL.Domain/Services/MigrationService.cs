using AutoMapper;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration;
using PAccountant2.BLL.Interfaces.Migration;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            var dbData = _mapper.Map<IEnumerable<CurrencyMigrationDataItem>>(mappedCurrencies);

            await _dataService.UpdateCurrenciesRatesAsync(dbData);
        }
    }
}
