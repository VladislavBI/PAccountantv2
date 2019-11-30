using System;
using System.Collections.Generic;
using System.Linq;
using CurrenctyRateUtil.Factory;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Services;
using PAccountant2.BLL.Domain.Entities.Currency;

namespace PAccountant2.BLL.Domain.Entities.Accounting.Handlers
{
    class CurrencyHandler
    {
        public decimal ConvertToRate(decimal amount, int baseCurrencyId, int resultCurrencyId, IEnumerable<ExchangeRateValueObject> rates)
        {
            CurrencyConvertModel convertModel = ConvertToRateSetup(amount, baseCurrencyId, resultCurrencyId, rates);

            CurrencyConvertService convertService = new CurrencyConvertService();
            var convertedAmount = convertService.ConvertToCurrency(convertModel);

            return convertedAmount;
        }

        private static CurrencyConvertModel ConvertToRateSetup(decimal amount, int baseCurrencyId, int resultCurrencyId, IEnumerable<ExchangeRateValueObject> rates)
        {
            var exchangeRateValueObjects = rates as ExchangeRateValueObject[] ?? rates.ToArray();
            if (rates == null || !exchangeRateValueObjects.Any())
            {
                throw new NullReferenceException("no exhange rates were sent");
            }

            CurrencyConvertFactory factory = new CurrencyConvertFactory();

            var exchangeRatesMapped = exchangeRateValueObjects.Select(r =>
                factory.CreateExchangeRateModel(r.Buy, r.Sell, r.ResultCurrencyId, r.BaseCurrencyId));

            var convertModel = factory.CreateConvertModel(amount, resultCurrencyId, baseCurrencyId);
            convertModel.Rates = exchangeRatesMapped;

            return convertModel;
        }
    }
}
