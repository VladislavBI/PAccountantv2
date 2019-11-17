using CurrenctyRateUtil.Enums;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CurrenctyRateUtil.Tests
{
    public class RatesConvertionTests
    {
        private const string FromCurrency = "USD";
        private const string ToCurrency = "EUR";
        private const string BaseCurrency = "UAH";

        public RateService RateService { get; set; }

        [SetUp]
        public void Setup()
        {
            RateService = new RateService(RateSource.PrivatBankUa);
        }

        [Test]
        public void ConvertRate_StraightFromTo_SameRate()
        {
            var baseRate = new SimpleRateModel
            {
                BaseCurrency = FromCurrency,
                Currency = ToCurrency,
                Sell = 24.5f,
                Buy = 24.3f
            };

            var rates = new List<SimpleRateModel>
            {
                baseRate
            };

            var newRate = RateService.ConvertRate(rates, FromCurrency, ToCurrency);

            Assert.AreSame(baseRate.BaseCurrency, newRate.BaseCurrency);
            Assert.AreSame(baseRate.Currency, newRate.Currency);
            Assert.That(baseRate.Sell, Is.EqualTo(newRate.Sell));
            Assert.That(baseRate.Buy, Is.EqualTo(newRate.Buy));
        }

        [Test]
        public void ConvertRate_RevertFromTo_RevertRate()
        {
            var baseRate = new SimpleRateModel
            {
                BaseCurrency = ToCurrency,
                Currency = FromCurrency,
                Sell = 1.5f,
                Buy = 1.3f
            };

            var rates = new List<SimpleRateModel>
            {
                baseRate
            };

            var newRate = RateService.ConvertRate(rates, FromCurrency, ToCurrency);

            Assert.AreSame(baseRate.BaseCurrency, newRate.Currency);
            Assert.AreSame(baseRate.Currency, newRate.BaseCurrency);
            Assert.That(newRate.Sell, Is.EqualTo(1 / baseRate.Sell));
            Assert.That(newRate.Buy, Is.EqualTo(1 / baseRate.Buy));
        }

        [Test]
        public void ConvertRate_CrossRateFromTo_CrossRate()
        {
            var fromRate = new SimpleRateModel
            {
                BaseCurrency = BaseCurrency,
                Currency = FromCurrency,
                Sell = 24.5f,
                Buy = 24.3f
            };

            var toRate = new SimpleRateModel
            {
                BaseCurrency = BaseCurrency,
                Currency = ToCurrency,
                Sell = 27.3f,
                Buy = 27f
            };

            var rates = new List<SimpleRateModel>
            {
                fromRate,
                toRate
            };

            var newRate = RateService.ConvertRate(rates, FromCurrency, ToCurrency);

            Assert.AreSame(newRate.BaseCurrency, FromCurrency);
            Assert.AreSame(newRate.Currency, ToCurrency);
            Assert.That(newRate.Sell, Is.EqualTo(fromRate.Sell / toRate.Sell));
            Assert.That(newRate.Buy, Is.EqualTo(fromRate.Buy / toRate.Buy));
        }
    }
}
