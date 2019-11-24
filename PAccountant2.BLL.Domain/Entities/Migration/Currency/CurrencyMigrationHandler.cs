using System;
using PAccountant2.BLL.Domain.Entities.Currency;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;
using PAccountant2.BLL.Interfaces.Migration;

namespace PAccountant2.BLL.Domain.Entities.Migration.Currency
{
    public class CurrencyMigrationHandler
    {

        internal IEnumerable<CurrencyEntity> GetCurrencies(IEnumerable<CurrencyIncomeValueObject> incomeData)
        {
            var currencyIncomeValueObjects = incomeData as CurrencyIncomeValueObject[] ?? incomeData.ToArray();

            var baseCurNames = currencyIncomeValueObjects.Select(data => data.BaseCurrency).Distinct();
            var resultCurNames = currencyIncomeValueObjects.Select(data => data.Currency).Distinct();
            var currenciesNames = baseCurNames.Union(resultCurNames);

            var currencies = currenciesNames.Select(name => new CurrencyEntity
            {
                Name = name
            });

            return currencies;
        }

        public async Task<IEnumerable<CurrencyEntity>> MigrateCurrenciesAsync(IEnumerable<CurrencyEntity> currencies, IMigrationDataService migrationDataService)
        {
            var currecinciesDataItem = currencies.Select(cur => new CurrencyDataItem
            {
                Name = cur.Name
            });

            var dbCurencies = await migrationDataService.UpdateCurreniesAsync(currecinciesDataItem);

            var updatedCurrencies = dbCurencies.Select(cur => new CurrencyEntity
            {
                Id = cur.Id,
                Name = cur.Name
            });

            return updatedCurrencies;
        }

        public IEnumerable<ExchangeRateEntity> GetExchangeRates(IEnumerable<CurrencyIncomeValueObject> incomeData, IEnumerable<CurrencyEntity> dbCurrencies)
        {
            var exchangeRates = incomeData.Select(data => new ExchangeRateEntity
            {
                BaseCurrency = 
                    dbCurrencies.FirstOrDefault
                    (cur => string.Equals(cur.Name, data.BaseCurrency, StringComparison.CurrentCultureIgnoreCase)),
                 ResultCurrency = 
                     dbCurrencies.FirstOrDefault(cur => string.Equals(cur.Name, data.Currency, StringComparison.CurrentCultureIgnoreCase)),
                Buy = data.Buy,
                Sell = data.Sell
            });

            return exchangeRates;
        }

        public async Task MigrateExchangeRates(IEnumerable<ExchangeRateEntity> exchangeRates, IMigrationDataService migrationDataService)
        {
            var dbRates = exchangeRates.Select(rate => new ExchangeRateDataItem
            {
                BaseCurrency = new CurrencyDataItem
                {
                    Id = rate.BaseCurrency.Id,
                    Name = rate.BaseCurrency.Name
                },
                ResultCurrency = new CurrencyDataItem
                {
                    Id = rate.ResultCurrency.Id,
                    Name = rate.ResultCurrency.Name
                },
                Buy = rate.Buy,
                Sell = rate.Sell
            });

            await migrationDataService.UpdateCurrenciesRatesAsync(dbRates);
        }
    }
}
