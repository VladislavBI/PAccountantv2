using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CurrenctyRateUtil.Enums;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Parsers;
using Newtonsoft.Json.Linq;

namespace CurrenctyRateUtil.Services
{
    public class GetSimpleRate
    {
        public RateSource RateSource { get; set; }
        public IRateParser Parser { get; set; }

        public GetSimpleRate(RateSource source)
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
    }
}
