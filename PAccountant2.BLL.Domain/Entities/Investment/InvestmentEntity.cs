using PAccountant2.BLL.Domain.Entities.Investment.Handlers;
using PAccountant2.BLL.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.Investment
{
    public class InvestmentEntity
    {
        private readonly PaymentDateHandler _paymentDateHandler;

        private readonly InvestmentTransactionHandler _transactionHandler;

        private readonly InvestmentOperationHandler _operationHandler;

        public int Id { get; set; }

        public InvestmentType InvestmentType { get; set; }

        public PaymentPeriod PaymentPeriod { get; set; }

        public decimal StartBodyAmount { get; set; }

        public decimal CurrentBodyAmount { get; set; }

        public float Percent { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Term { get; set; }

        public string Comment { get; set; }

        public DateTime LastPayment { get; set; }

        public bool Completed { get; set; }

        public IEnumerable<InvestmentOperationValueObject> Operations { get; set; }


        public InvestmentEntity()
        {
            _paymentDateHandler = new PaymentDateHandler();
            _transactionHandler = new InvestmentTransactionHandler();
            _operationHandler = new InvestmentOperationHandler();
        }

        public bool IsPaymentPeriod()
            => _paymentDateHandler.IsPaymentPeriod(PaymentPeriod, LastPayment);

        public InvestmentOperationValueObject AddNewPaymentAuto(DateTime newPaymentDate, string comment)
        {
            InvestmentTransactionValueObject transactionValueObject = CreateNewTransaction(CurrentBodyAmount, StartBodyAmount, InvestmentType, Percent);
            var transactionResult = _transactionHandler.PutMoneyToInvestmentByPercent(transactionValueObject);

            var newOperation = CreateNewOperation(transactionResult.PaymentAmount, transactionResult.CurrentBodyAmount, comment);
            var updatedOperations = _operationHandler.AddNewOperation(newOperation, Operations);

            var isCompleted = _paymentDateHandler.IsCompleted(StartDate, Term);

            UpdateInvestmentData(newPaymentDate, transactionResult.CurrentBodyAmount, updatedOperations, isCompleted);

            return newOperation;
        }

        private void UpdateInvestmentData(DateTime newPaymentDate, decimal currentBodyAmount, IEnumerable<InvestmentOperationValueObject> updatedOperations, bool isCompleted)
        {
            CurrentBodyAmount = currentBodyAmount;
            LastPayment = newPaymentDate;
            Operations = updatedOperations;
            Completed = isCompleted;
        }

        private InvestmentTransactionValueObject CreateNewTransaction
            (decimal currentBodyAmount, decimal startBodyAmount, InvestmentType investmentType, float percent)
        {
            return new InvestmentTransactionValueObject
            {
                CurrentBodyAmount = currentBodyAmount,
                InvestmentType = investmentType,
                PaymentPercent = percent,
                StartBodyAmount = startBodyAmount
            };
        }

        private InvestmentOperationValueObject CreateNewOperation(decimal paymentPercent, decimal newBodyAmount, string comment)
        {
            var newOperation = new InvestmentOperationValueObject
            {
                Amount = paymentPercent,
                Date = DateTime.Now,
                Comment = comment,
                NewTotalAmount = newBodyAmount
            };

            return newOperation;
        }
    }
}