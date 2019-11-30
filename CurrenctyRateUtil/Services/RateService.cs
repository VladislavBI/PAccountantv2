using CurrenctyRateUtil.Enums;
using CurrenctyRateUtil.Infrastructure;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenctyRateUtil.Services
{
    public class RateService : IRateService
    {
        public RateSource RateSource { get; set; }

        public IRateParser Parser { get; set; }

        public RateConverter RateConverter { get; set; }

        public RateService():this(RateSource.PrivatBankUa)
        {
        }

        public RateService(RateSource source)
        {
            RateSource = source;
            Parser = new PrivatBankParser();
            RateConverter = new RateConverter();
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

            rateModel = RemoveNullRates(rateModel).ToList();

            return rateModel;
        }

        public SimpleRateModel ConvertRate(List<SimpleRateModel> rates, string from, string to)
        {

            if (rates == null || !rates.Any())
            {
                throw new NullReferenceException("no rates were sent");
            }

            SimpleRateModel resultRate = RateConverter.ConvertProcess(rates, from, to);

            return resultRate;
        }

        private static IEnumerable<SimpleRateModel> RemoveNullRates(List<SimpleRateModel> rateModel)
        {
            var notNulRates = rateModel.Where(r => Math.Abs(r.Buy) > 0 && Math.Abs(r.Sell) > 0);

            return notNulRates;
        }

        
    }
}
