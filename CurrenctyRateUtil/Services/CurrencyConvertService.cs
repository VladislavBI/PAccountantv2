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

            resultAmount = resultAmount ?? CrossRateResultsConvert(model, resultAmount);
            resultAmount = resultAmount ?? CrossRateBasesConvert(model, resultAmount);
            resultAmount = resultAmount ?? CrossRateResultBaseConvert(model, resultAmount);
            resultAmount = resultAmount ?? CrossRateBaseResultConvert(model, resultAmount);

            return resultAmount ?? model.Amount;
        }

        private static decimal? CrossRateBaseResultConvert(CurrencyConvertModel model, decimal? resultAmount)
        {
            var fromRate = model.Rates.FirstOrDefault(r => r.BaseCurrencyId == model.BaseCurrencyId);
            var toRate = model.Rates.FirstOrDefault(r => r.ResultCurrencyId == model.ResultCurrencyId);

            if (fromRate != null && toRate != null
                                 && fromRate.ResultCurrencyId == toRate.BaseCurrencyId)
            {
                var convertedRate = Convert.ToDecimal(fromRate.Buy * toRate.Buy);
                resultAmount = convertedRate * model.Amount;
            }

            return resultAmount;
        }

        private static decimal? CrossRateResultBaseConvert(CurrencyConvertModel model, decimal? resultAmount)
        {
            var fromRate = model.Rates.FirstOrDefault(r => r.ResultCurrencyId == model.BaseCurrencyId);
            var toRate = model.Rates.FirstOrDefault(r => r.BaseCurrencyId == model.ResultCurrencyId);

            if (fromRate != null && toRate != null
                                 && fromRate.ResultCurrencyId == toRate.BaseCurrencyId)
            {
                var convertedRate = Convert.ToDecimal(fromRate.Sell * toRate.Sell);
                resultAmount = convertedRate / model.Amount;
            }

            return resultAmount;
        }

        private static decimal? CrossRateBasesConvert(CurrencyConvertModel model, decimal? resultAmount)
        {
            var fromRate = model.Rates.FirstOrDefault(r => r.BaseCurrencyId == model.BaseCurrencyId);
            var toRate = model.Rates.FirstOrDefault(r => r.BaseCurrencyId == model.ResultCurrencyId);

            if (fromRate != null && toRate != null
                                 && fromRate.BaseCurrencyId == toRate.BaseCurrencyId)
            {
                var convertedRate = Convert.ToDecimal(toRate.Sell / fromRate.Buy);
                resultAmount = convertedRate * model.Amount;
            }

            return resultAmount;
        }

        private static decimal? CrossRateResultsConvert(CurrencyConvertModel model, decimal? resultAmount)
        {
            var fromRate = model.Rates.FirstOrDefault(r => r.ResultCurrencyId == model.BaseCurrencyId);
            var toRate = model.Rates.FirstOrDefault(r => r.ResultCurrencyId == model.ResultCurrencyId);
            if (fromRate != null && toRate != null
                                 && fromRate.ResultCurrencyId == toRate.ResultCurrencyId)
            {
                var convertedRate = Convert.ToDecimal(toRate.Buy / toRate.Sell);
                resultAmount = convertedRate * model.Amount;
            }

            return resultAmount;
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
            if (model.Rates.Any(sameRate))
            {
                var exchangeRate = model.Rates.FirstOrDefault(sameRate);
                var decimalBuy = Convert.ToDecimal(exchangeRate.Buy);

                resultAmount = model.Amount * decimalBuy;
            }

            return resultAmount;
        }
    }
}
