using CurrenctyRateUtil.Models;
using System;
using System.Linq;

namespace CurrenctyRateUtil.Services
{
    public class CurrencyConvertService
    {
        public decimal ConvertToCurrency(CurrencyConvertModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("no model were sent to convert");
            }

            if (model.Rates == null || !model.Rates.Any())
            {
                throw new NullReferenceException("no exhange rates were sent");
            }

            decimal? resultAmount = null;
            Func<ExchangeRateModel, bool> sameRate
                = r => r.BaseCurrencyId == model.BaseCurrencyId && r.ResultCurrencyId == model.ResultCurrencyId;

            Func<ExchangeRateModel, bool> revertRate
                = r => r.BaseCurrencyId == model.ResultCurrencyId && r.ResultCurrencyId == model.BaseCurrencyId;

            resultAmount = SameRateConvert(model, resultAmount, sameRate);
            resultAmount = resultAmount ?? RevertRateConvert(model, resultAmount, revertRate);

            return resultAmount ?? model.Amount;
        }

        private static decimal? RevertRateConvert(CurrencyConvertModel model, decimal? resultAmount, Func<ExchangeRateModel, bool> revertRate)
        {
            if (model.Rates.Any(r => revertRate(r)))
            {

                var exchangeRate = model.Rates.FirstOrDefault(r => revertRate(r));
                var decimalSell = Convert.ToDecimal(exchangeRate.Sell);

                resultAmount = model.Amount / decimalSell;
            }

            return resultAmount;
        }

        private static decimal? SameRateConvert(CurrencyConvertModel model, decimal? resultAmount, Func<ExchangeRateModel, bool> sameRate)
        {
            if (model.Rates.Any(r => sameRate(r)))
            {

                var exchangeRate = model.Rates.FirstOrDefault(r => sameRate(r));
                var decimalBuy = Convert.ToDecimal(exchangeRate.Buy);

                resultAmount = model.Amount * decimalBuy;
            }

            return resultAmount;
        }
    }
}
