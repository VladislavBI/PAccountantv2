using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Interfaces.Migration
{
    public interface IMigrationService
    {
        Task<bool> IsCurrenciesCreatedAsync();

        Task AddCurrenciesAsync(IEnumerable<DTO.ViewItems.Migration.CurrencyMigrationViewItem> mappedCurrencies);

        Task UpdateCurrenciesRatesAsync(System.Collections.Generic.IEnumerable<DTO.ViewItems.Migration.ExchangeRatesMigrationViewItem> mappedCurrencies);
    }
}
