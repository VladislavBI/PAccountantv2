using System;
using CurrenctyRateUtil.Models;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurrenctyRateUtil.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<CurrenciesArrayModel> GetAllCurrencies()
        {
            WebClient client = new WebClient();
            var xmlResponse =
                await client.DownloadDataTaskAsync("https://www.currency-iso.org/dam/downloads/lists/list_one.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(CurrenciesArrayModel));
            using (MemoryStream str = new MemoryStream(xmlResponse))
            {
                var data = (CurrenciesArrayModel)serializer.Deserialize(str);
                return data;
            }

        }
    }
}
