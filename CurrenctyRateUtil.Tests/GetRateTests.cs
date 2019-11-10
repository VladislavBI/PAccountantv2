using System.Linq;
using System.Threading.Tasks;
using CurrenctyRateUtil.Parsers;
using Moq;
using NUnit.Framework;

namespace CurrenctyRateUtil.Tests
{
    public class GetRateTests
    {
        private IRateParser parser;

        [Test]
        public async Task GetSimpleRatesPb()
        {
            parser = new PrivatBankParser();
            var model = await parser.GetSimpleRateData();
            var baseRates = model.Select(x => x.BaseCurrency);

            Assert.IsNotNull(model);
            Assert.IsTrue(model.All(r => r.Buy <= r.Sell));
            Assert.IsTrue(baseRates.All(r => r == "UAH"));
            CollectionAssert.IsNotEmpty(model);

        }
    }
}
