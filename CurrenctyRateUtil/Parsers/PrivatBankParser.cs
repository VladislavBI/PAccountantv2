using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CurrenctyRateUtil.Constants;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Models.ResponseModels;
using Newtonsoft.Json;

namespace CurrenctyRateUtil.Parsers
{
    public class PrivatBankParser: IRateParser
    {
        public async Task<IEnumerable<SimpleRateModel>> GetSimpleRateData()
        {
            var uriString = CreateRequestUri();

            var pbRates = await GetPbRates(uriString);

            if (pbRates?.ExchangeRate == null || !pbRates.ExchangeRate.Any())
            {
                throw new Exception("No rates were loaded");
            }

            var rates = MapToSimpleModel(pbRates);

            return rates;
        }

        private static async Task<PBResponseModel> GetPbRates(Uri uriString)
        {
            WebClient client = new WebClient();
            var respJson = await client.DownloadStringTaskAsync(uriString);

            var pbResponse = JsonConvert.DeserializeObject<PBResponseModel>(respJson);
            return pbResponse;
        }

        private static IEnumerable<SimpleRateModel> MapToSimpleModel(PBResponseModel pbRates)
        {
            return pbRates.ExchangeRate.Select(r => new SimpleRateModel
            {
                Currency = r.Currency,
                BaseCurrency = r.BaseCurrency,
                Buy = r.PurchaseRate,
                Sell = r.SaleRate
            });
        }

        Uri CreateRequestUri()
        {
            var date = DateTime.Now;
            var stringDate = date.ToString("dd.MM.yyyy");

            var sourceApi = RequestUris.PrivatBank;
            var uriString = $"{sourceApi}{stringDate}";

            var uri = new Uri(uriString);
            return uri;
        }
    }
}
