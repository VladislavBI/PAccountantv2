using System;
using CurrenctyRateUtil.Enums;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Parsers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenctyRateUtil.Services
{
    public class RateService
    {
        public RateSource RateSource { get; set; }
        public IRateParser Parser { get; set; }

        public RateService(RateSource source)
        {
            RateSource = source;
            Parser = new PrivatBankParser();
        }
        public async Task<IEnumerable<SimpleRateModel>> GetCurrentSimpleRates()
        {
            List<SimpleRateModel> rateModel = new List<SimpleRateModel>();

            switch (RateSource)
            {
                case RateSource.PrivatBankUa:
                    rateModel = (await Parser.GetSimpleRateData()).ToList();
                    break;
            }

            return rateModel;
        }

        public SimpleRateModel ConvertRate(List<SimpleRateModel> rates, string from, string to)
        {
            SimpleRateModel resultRate = null;
            var copiedRates = rates.ConvertAll(x => x.Clone() as SimpleRateModel);

            if (rates == null || !rates.Any())
            {
                throw new NullReferenceException("no rates were sent");
            }

            resultRate = TryGetStraightRate(copiedRates, from, to);
            resultRate = resultRate ?? TryGetRevertRate(copiedRates, from, to);
            resultRate = resultRate ?? TryGetBySameBase(copiedRates, from, to);

            return resultRate;
        }

        private static SimpleRateModel TryGetBySameBase(List<SimpleRateModel> rates, string from, string to)
        {
            SimpleRateModel resultRate = null;

            var fromRate = rates.FirstOrDefault(r => string.Equals(r.Currency, from, StringComparison.CurrentCultureIgnoreCase));
            var toRate = rates.FirstOrDefault(r => string.Equals(r.Currency, to, StringComparison.CurrentCultureIgnoreCase));

            if (fromRate != null && toRate != null 
                                 && string.Equals(fromRate.BaseCurrency, toRate.BaseCurrency, StringComparison.CurrentCultureIgnoreCase))
            {
                resultRate = new SimpleRateModel
                {
                    BaseCurrency = from,
                    Currency = to,
                    Sell = fromRate.Sell / toRate.Sell,
                    Buy = fromRate.Buy / toRate.Buy
                };
            }

            return resultRate;
        }

        private static SimpleRateModel TryGetStraightRate(List<SimpleRateModel> rates, string from, string to)
        {
            SimpleRateModel resultRate = null;

            bool StraightRateExpr(SimpleRateModel r) =>
                string.Equals(r.BaseCurrency, from, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(r.Currency, to, StringComparison.CurrentCultureIgnoreCase);

            if (rates.Any(StraightRateExpr))
            {
                resultRate = rates.FirstOrDefault(StraightRateExpr);
            }

            return resultRate;
        }

        private static SimpleRateModel TryGetRevertRate(List<SimpleRateModel> rates, string from, string to)
        {
            SimpleRateModel resultRate = null;

             bool RevertRateExpr(SimpleRateModel r) =>
                    string.Equals(r.BaseCurrency, to, StringComparison.CurrentCultureIgnoreCase)
                    && string.Equals(r.Currency, from, StringComparison.CurrentCultureIgnoreCase);
            ;

            if (rates.Any(RevertRateExpr))
            {
                resultRate = rates.FirstOrDefault(RevertRateExpr);
                resultRate.BaseCurrency = from;
                resultRate.Currency = to;
                resultRate.Buy = 1 / resultRate.Buy;
                resultRate.Sell = 1 / resultRate.Sell;
            }

            return resultRate;
        }
    }
}
