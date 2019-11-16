using System.Collections.Generic;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;

namespace PAccountant2.BLL.Interfaces.Migration
{
    public interface IMigrationDataService
    {
        Task UpdateCurrenciesRatesAsync(IEnumerable<CurrencyMigrationDataItem> dbData);
    }
}
