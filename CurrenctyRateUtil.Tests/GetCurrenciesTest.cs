using System.Threading.Tasks;
using CurrenctyRateUtil.Services;
using NUnit.Framework;

namespace CurrenctyRateUtil.Tests
{
    public class GetCurrenciesTest
    {
        [Test]
        public async Task GetCurrencies()
        {
            var service = new CurrencyService();
            await service.GetAllCurrencies();
        }
    }
}
