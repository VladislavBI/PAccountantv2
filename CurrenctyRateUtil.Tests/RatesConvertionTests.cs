using System;
using CurrenctyRateUtil.Enums;
using CurrenctyRateUtil.Models;
using CurrenctyRateUtil.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CurrenctyRateUtil.Tests
{
    public class RatesConvertionTests
    {
        private const string fromCurrency = "USD";
        private const string toCurrency = "EUR";
        private const string baseCurrency = "UAH";

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
                BaseCurrency = fromCurrency,
                Currency = toCurrency,
                Sell = 24.5f,
                Buy = 24.3f
            };

            var rates = new List<SimpleRateModel>
            {
                baseRate
            };

            var newRate = RateService.ConvertRate(rates, fromCurrency, toCurrency);

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
                BaseCurrency = toCurrency,
                Currency = fromCurrency,
                Sell = 1.5f,
                Buy = 1.3f
            };

            var rates = new List<SimpleRateModel>
            {
                baseRate
            };

            var newRate = RateService.ConvertRate(rates, fromCurrency, toCurrency);

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
                BaseCurrency = baseCurrency,
                Currency = fromCurrency,
                Sell = 24.5f,
                Buy = 24.3f
            };

            var toRate = new SimpleRateModel
            {
                BaseCurrency = baseCurrency,
                Currency = toCurrency,
                Sell = 27.3f,
                Buy = 27f
            };

            var rates = new List<SimpleRateModel>
            {
                fromRate,
                toRate
            };

            var newRate = RateService.ConvertRate(rates, fromCurrency, toCurrency);

            Assert.AreSame(newRate.BaseCurrency, fromCurrency);
            Assert.AreSame(newRate.Currency, toCurrency);
            Assert.That(newRate.Sell, Is.EqualTo(fromRate.Sell / toRate.Sell));
            Assert.That(newRate.Buy, Is.EqualTo(fromRate.Buy / toRate.Buy));
        }
    }
}
