using CurrenctyRateUtil.Constants;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Models.ResponseModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CurrenctyRateUtil.Parsers
{
    public class MonobankParser : IRateParser
    {
        public async Task<IEnumerable<SimpleRateModel>> GetSimpleRateData()
        {
            WebClient client = new WebClient();
            var jsonData = await client.DownloadStringTaskAsync(RequestUris.Monobank);

            var rates = JsonConvert.DeserializeObject<IEnumerable<MonobankResponseModel>>(jsonData);
            var mappedRates = rates.Select(r => new SimpleRateModel
            {
                BaseCode = r.CurrencyCodeA,
                Buy = r.RateBuy,
                ResultCode = r.CurrencyCodeB,
                Sell = r.RateSell
            });

            return mappedRates;
        }

    }
}

