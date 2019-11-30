using System;

namespace PAccountant2.BLL.Domain.Entities.Currency.Handlers
{
    class CurrencyFactory
    {
        public ExchangeRateValueObject CreateExchangeRateValueObject(ExchangeRateEntity rateEntity)
        {
            if (rateEntity?.ResultCurrency == null || rateEntity?.BaseCurrency == null)
            {
                throw new NullReferenceException("invalod rate entity was sent");
            }

            var newVo = CreateExchangeRateValueObject(rateEntity.Buy, rateEntity.Sell, rateEntity.BaseCurrency.Id,
                rateEntity.ResultCurrency.Id);

            return newVo;
        }

        public ExchangeRateValueObject CreateExchangeRateValueObject(float buy, float sell, int baseId, int resultId)
        {

            var newVo = new ExchangeRateValueObject
            {
                BaseCurrencyId = baseId,
                ResultCurrencyId = resultId,
                Buy = buy,
                Sell = sell
            };

            return newVo;
        }
    }
}
