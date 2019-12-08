using AutoMapper;
using EFCore.BulkExtensions;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;
using PAccountant2.BLL.Interfaces.Migration;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoreLinq.Extensions;
using PAccountant2.BLL.Domain.Entities.Currency;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;
using PAccountant2.DAL.DBO.Entities.Currency;

namespace PAccountant2.DAL.Services
{
    public class MigrationsDataService: IMigrationDataService
    {
        private readonly PaccountantContext _context;

        private readonly IMapper _mapper;

        public MigrationsDataService(PaccountantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      
        public async Task<IEnumerable<CurrencyDataItem>> UpdateCurreniesAsync(IEnumerable<CurrencyDataItem> currencies)
        {
            var currenciesForAdd = _mapper.Map<IEnumerable<CurrencyDbo>>(currencies);
            var dbCurrencies = await _context.Currencies.ToListAsync();
            currenciesForAdd = currenciesForAdd.ExceptBy(dbCurrencies, cur => cur.Name);

            _context.Currencies.AddRange(currenciesForAdd);
            await _context.SaveChangesAsync();

            var updatedCurrencies = _mapper.Map<IEnumerable<CurrencyDataItem>>(currenciesForAdd);

            return updatedCurrencies;
        }

        public async Task UpdateCurrenciesRatesAsync(IEnumerable<ExchangeRateDataItem> dbRates)
        {
            var currentRates = await _context.ExchangeRates
                .Include(x => x.BaseCurrency)
                .Include(x => x.ResultCurrency)
                .ToListAsync();

            var mappedParamRates = _mapper.Map<IEnumerable<ExchangeRateDbo>>(dbRates);

            bool ExchangeRateExists(ExchangeRateDbo rate1, ExchangeRateDbo rate2) =>
                rate1.BaseCurrencyId == rate2.BaseCurrencyId && rate1.ResultCurrencyId == rate2.ResultCurrencyId;

            foreach (var rate in mappedParamRates)
            {
               
                if (currentRates.Any(r => ExchangeRateExists(rate, r)))
                {
                    var rateForUpdate = currentRates.FirstOrDefault(r => ExchangeRateExists(rate, r));

                    rateForUpdate.Buy = rate.Buy;
                    rateForUpdate.Sell = rate.Sell;
                }
                else
                {
                    _context.ExchangeRates.Add(rate);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsCurrenciesCreatedAsync()
            => await _context.Currencies.AnyAsync();

        public async Task AddCurrenciesAsync(IEnumerable<CurrencyMigrationDataItem> mappedCurrencies)
        {
            var dbCurrencies = mappedCurrencies.Select(x => new CurrencyDbo
            {
                Code = x.Number,
                Name = x.Code,
                FullName = x.FullName
            });
            
            _context.Currencies.AddRange(dbCurrencies);

            await _context.SaveChangesAsync();
        }
    }
}
