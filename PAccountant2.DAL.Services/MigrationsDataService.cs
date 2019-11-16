using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;
using PAccountant2.BLL.Interfaces.Migration;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;

namespace PAccountant2.DAL.Services
{
    public class MigrationsDataService: IMigrationDataService
    {
        private readonly PaccountantContext _context;

        public MigrationsDataService(PaccountantContext context)
        {
            _context = context;
        }

        public async Task UpdateCurrenciesRatesAsync(IEnumerable<CurrencyMigrationDataItem> dbData)
        {
            var (newRates, savedCurrencies, currencyRateExists) = UpdateCurrencySetup(dbData);

            UpdateCurrenciesProcess(newRates, savedCurrencies, currencyRateExists);

            await _context.SaveChangesAsync();

        }

        private (IEnumerable<CurrencyDbo> newRates, List<CurrencyDbo> savedCurrency, Func<CurrencyDbo, CurrencyDbo, bool> currencyRateExists)
            UpdateCurrencySetup(IEnumerable<CurrencyMigrationDataItem> dbData)
        {
            bool CurrencyRateExists(CurrencyDbo cur, CurrencyDbo rate) => 
                string.Equals(cur.BaseCurrency, rate.BaseCurrency, StringComparison.CurrentCultureIgnoreCase) 
                && string.Equals(cur.Currency, rate.Currency, StringComparison.CurrentCultureIgnoreCase);


            var newRates = dbData.Select(cur => new CurrencyDbo
            {
                BaseCurrency = cur.BaseCurrency,
                Buy = cur.Buy,
                Currency = cur.Currency,
                Sell = cur.Sell
            });

            var savedCurrencies = _context.Currencies.ToList();

            return (newRates, savedCurrencies, CurrencyRateExists);
        }

        private void UpdateCurrenciesProcess(IEnumerable<CurrencyDbo> newRates, List<CurrencyDbo> savedCurrencies, Func<CurrencyDbo, CurrencyDbo, bool> currencyRateExists)
        {
            foreach (var rate in newRates)
            {

                if (savedCurrencies.Any(cur => currencyRateExists(cur, rate)))
                {
                    UpdateCurrency(savedCurrencies, rate, currencyRateExists);
                }
                else
                {
                    AddCurrency(rate);
                }

            }
        }

 
        private void AddCurrency(CurrencyDbo rate)
        {
            var newCurrency = new CurrencyDbo
            {
                BaseCurrency = rate.BaseCurrency,
                Buy = rate.Buy,
                Currency = rate.Currency,
                Sell = rate.Sell
            };

            _context.Currencies.Add(newCurrency);
        }

        private static void UpdateCurrency(List<CurrencyDbo> savedCurrencies, CurrencyDbo rate, Func<CurrencyDbo, CurrencyDbo, bool> currencyRateExists)
        {
            var updatedCurrency = savedCurrencies.FirstOrDefault(cur => currencyRateExists(cur, rate));

            updatedCurrency.Buy = rate.Buy;
            updatedCurrency.Sell = rate.Sell;
        }
    }
}
