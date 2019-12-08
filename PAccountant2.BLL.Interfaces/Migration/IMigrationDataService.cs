using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;
using System.Collections.Generic;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;

namespace PAccountant2.BLL.Interfaces.Migration
{
    public interface IMigrationDataService
    {
        Task<IEnumerable<CurrencyDataItem>> UpdateCurreniesAsync(IEnumerable<CurrencyDataItem> currencies);
        
        Task UpdateCurrenciesRatesAsync(IEnumerable<ExchangeRateDataItem> dbRates);

        Task<bool> IsCurrenciesCreatedAsync();

        Task AddCurrenciesAsync(IEnumerable<CurrencyMigrationDataItem> mappedCurrencies);
    }
}
