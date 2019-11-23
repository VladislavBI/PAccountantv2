using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreLinq.Experimental;
using PAccountant2.BLL.Domain.Entities.Currency;
using PAccountant2.BLL.Domain.Entities.Migration.Currency;
using PAccountant2.BLL.Interfaces.Migration;

namespace PAccountant2.BLL.Domain.Entities.Migration
{
    public class MigrationEntity
    {
        public async Task MigrateCurrencies(IEnumerable<CurrencyIncomeValueObject> incomeData, IMigrationDataService migrationDataService)
        {
            var incomingDataList = incomeData.ToList();

            if (incomeData == null || !incomingDataList.Any())
            {
                throw new Exception("No currencies for migration were get");
            }

            var migrationHandler = new CurrencyMigrationHandler();

            IEnumerable<CurrencyEntity> currencies =
                migrationHandler.GetCurrencies(incomingDataList);

            var dbCurrencies = await migrationHandler.MigrateCurrenciesAsync(currencies, migrationDataService);

            var exchangeRates = migrationHandler.GetExchangeRates(incomingDataList, dbCurrencies);

            await migrationHandler.MigrateExchangeRates(exchangeRates, migrationDataService);
        }
    }
}
