using CurrenctyRateUtil.Constants;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Models.ResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrenctyRateUtil.Parsers
{
    public class PrivatBankParser : IRateParser
    {
        private const string DateFormat = "dd.MM.yyyy";

        public async Task<IEnumerable<SimpleRateModel>> GetSimpleRateData()
        {
            var uriString = CreateRequestUri();

            var pbRates = await GetPbRates(uriString);

            if (pbRates?.ExchangeRate == null || !pbRates.ExchangeRate.Any())
            {
                throw new NullReferenceException("No rates were loaded");
            }

            var rates = MapToSimpleModel(pbRates);

            return rates;
        }

        private static async Task<PBResponseModel> GetPbRates(Uri uriString)
        {
            WebClient client = new WebClient();
            var respJson = await client.DownloadStringTaskAsync(uriString);

            var format = DateFormat;
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };

            var pbResponse = JsonConvert.DeserializeObject<PBResponseModel>(respJson, dateTimeConverter);

            return pbResponse;
        }

        private static IEnumerable<SimpleRateModel> MapToSimpleModel(PBResponseModel pbRates)
        {
            return pbRates.ExchangeRate.Select(r => new SimpleRateModel
            {
                Currency = r.BaseCurrency,
                BaseCurrency = r.Currency,
                Buy = r.PurchaseRate,
                Sell = r.SaleRate
            });
        }

        Uri CreateRequestUri()
        {
            var date = DateTime.Now;
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(-1);
            }
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(-2);
            }

            var stringDate = date.ToString(DateFormat);

            var sourceApi = RequestUris.PrivatBank;
            var uriString = $"{sourceApi}{stringDate}";

            var uri = new Uri(uriString);
            return uri;
        }
    }
}
