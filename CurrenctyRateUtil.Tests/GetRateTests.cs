using CurrenctyRateUtil.Parsers;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenctyRateUtil.Tests
{
    public class GetRateTests
    {
        private IRateParser _parser;

        [Test]
        public async Task GetSimpleRatesPb()
        {
            _parser = new PrivatBankParser();
            var model = await _parser.GetSimpleRateData();
            var baseRates = model.Select(x => x.BaseCurrency);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.All(r => r.Buy <= r.Sell));
            Assert.IsTrue(baseRates.All(r => r == "UAH"));
            CollectionAssert.IsNotEmpty(model);

        }
    }
}
