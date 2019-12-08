using PAccountant2.BLL.Domain.Enum;
using System;

namespace PAccountant2.BLL.Domain.Entities.Investment.Handlers
{
    class InvestmentTransactionHandler
    {
        public InvestmentTransactionResultValueObject PutMoneyToInvestmentByPercent(InvestmentTransactionValueObject transactionVo)
        {
            var transactionResult = new InvestmentTransactionResultValueObject();

            transactionResult.PaymentAmount = GetPaymentAmountByPercent(transactionVo);

            transactionResult.CurrentBodyAmount = transactionVo.CurrentBodyAmount + transactionResult.PaymentAmount;

            return transactionResult;
        }

        public decimal GetPaymentAmountByPercent(InvestmentTransactionValueObject transactionVo)
        {
            var paymentAmount = default(decimal);
            var decimalPercent = Convert.ToDecimal(transactionVo.PaymentPercent);

            switch (transactionVo.InvestmentType)
            {
                case InvestmentType.SimpleDeposit:
                    paymentAmount = transactionVo.StartBodyAmount * decimalPercent / 100;
                    break;

                case InvestmentType.ComplexDeposit:
                    paymentAmount = transactionVo.CurrentBodyAmount * decimalPercent / 100;
                    break;
            }

            return paymentAmount;
        }
    }
}
