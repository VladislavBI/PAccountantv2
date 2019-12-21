using System;
using System.Collections.Generic;
using System.Linq;
using CurrenctyRateUtil.Models;

namespace CurrenctyRateUtil.Infrastructure
{
    public class RateConverter
    {
        public SimpleRateModel ConvertProcess(List<SimpleRateModel> rates, string from, string to)
        {
            var copiedRates = Setup(rates);
            var resultRate = Process(from, to, copiedRates.ToList());

            return resultRate;
        }

        private IEnumerable<SimpleRateModel> Setup(List<SimpleRateModel> rates)
        {
            if (rates == null || !rates.Any())
            {
                throw new NullReferenceException("no rates were sent");
            }

            var copiedRates = rates.ConvertAll(x => x.Clone() as SimpleRateModel);

            return copiedRates;
        }

        private SimpleRateModel Process(string from, string to, List<SimpleRateModel> copiedRates)
        {
            SimpleRateModel resultRate = TryGetStraightRate(copiedRates, from, to);
            resultRate = resultRate ?? TryGetRevertRate(copiedRates, from, to);
            resultRate = resultRate ?? TryGetBySameBase(copiedRates, from, to);
            return resultRate;
        }



        private SimpleRateModel TryGetBySameBase(List<SimpleRateModel> rates, string from, string to)
        {
            SimpleRateModel resultRate = null;

            var fromRate = rates.FirstOrDefault(r => string.Equals(r.ResultCurrency, from, StringComparison.CurrentCultureIgnoreCase));
            var toRate = rates.FirstOrDefault(r => string.Equals(r.ResultCurrency, to, StringComparison.CurrentCultureIgnoreCase));

            if (fromRate != null && toRate != null
                                 && string.Equals(fromRate.BaseCurrency, toRate.BaseCurrency, StringComparison.CurrentCultureIgnoreCase))
            {
                resultRate = new SimpleRateModel
                {
                    BaseCurrency = from,
                    ResultCurrency = to,
                    Sell = fromRate.Sell / toRate.Sell,
                    Buy = fromRate.Buy / toRate.Buy
                };
            }

            return resultRate;
        }

        private SimpleRateModel TryGetStraightRate(List<SimpleRateModel> rates, string from, string to)
        {
            SimpleRateModel resultRate = null;

            bool StraightRateExpr(SimpleRateModel r) =>
                string.Equals(r.BaseCurrency, from, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(r.ResultCurrency, to, StringComparison.CurrentCultureIgnoreCase);

            if (rates.Any(StraightRateExpr))
            {
                resultRate = rates.FirstOrDefault(StraightRateExpr);
            }

            return resultRate;
        }

        private SimpleRateModel TryGetRevertRate(List<SimpleRateModel> rates, string from, string to)
        {
            SimpleRateModel resultRate = null;

            bool RevertRateExpr(SimpleRateModel r) =>
                   string.Equals(r.BaseCurrency, to, StringComparison.CurrentCultureIgnoreCase)
                   && string.Equals(r.ResultCurrency, from, StringComparison.CurrentCultureIgnoreCase);
            ;

            if (rates.Any(RevertRateExpr))
            {
                resultRate = rates.FirstOrDefault(RevertRateExpr);

                resultRate.BaseCurrency = from;
                resultRate.ResultCurrency = to;
                resultRate.Buy = 1 / resultRate.Buy;
                resultRate.Sell = 1 / resultRate.Sell;
            }

            return resultRate;
        }
    }
}
