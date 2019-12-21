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

        public RateService():this(RateSource.MonobankUa)
        {
        }

        public RateService(RateSource source)
        {
            RateSource = source;
            switch (source)
            {
                case RateSource.PrivatBankUa:
                    Parser = new PrivatBankParser();
                    break;
                case RateSource.MonobankUa:
                    Parser = new MonobankParser();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(source), source, null);
            }
            RateConverter = new RateConverter();
        }

        public async Task<IEnumerable<SimpleRateModel>> GetCurrentSimpleRates()
        {
            List<SimpleRateModel> rateModel = new List<SimpleRateModel>();

            rateModel = (await Parser.GetSimpleRateData()).ToList();

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

            return notNulRates.ToList();
        }

        
    }
}
