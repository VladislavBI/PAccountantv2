using CurrenctyRateUtil.Models;

namespace CurrenctyRateUtil.Factory
{
    public class CurrencyConvertFactory
    {
        public ExchangeRateModel CreateExchangeRateModel(float buy, float sell, int resultId, int baseId)
        {
            var newRateModel = new ExchangeRateModel
            {
                Buy = buy,
                Sell = sell,
                ResultCurrencyId = resultId,
                BaseCurrencyId = baseId
            };

            return newRateModel;
        }

        public CurrencyConvertModel CreateConvertModel(decimal amount, int resultId, int baseId)
        {
            var newConvertModel = new CurrencyConvertModel
            {
                Amount = amount,
                ResultCurrencyId = resultId,
                BaseCurrencyId = baseId
            };

            return newConvertModel;
        }
    }
}
