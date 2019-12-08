using PAccountant2.BLL.Domain.Enum;
using System;

namespace PAccountant2.BLL.Domain.Entities.Investment.Handlers
{
    class PaymentDateHandler
    {

        public bool IsPaymentPeriod(PaymentPeriod paymentPeriod, DateTime lastPayment)
        {
            var newPaymentDate = new DateTime();

            switch (paymentPeriod)
            {
                case PaymentPeriod.Day:
                    newPaymentDate = lastPayment.AddDays(1);
                    break;

                case PaymentPeriod.Month:
                    newPaymentDate = lastPayment.AddMonths(1);
                    break;

                case PaymentPeriod.Year:
                    newPaymentDate = lastPayment.AddYears(1);
                    break;
            }

            return newPaymentDate.Date <= DateTime.Now.Date;
        }

        public bool IsCompleted(DateTime startDate, TimeSpan term)
        {
            var endDate = (startDate + term).Date;

            return endDate <= DateTime.Now.Date;
        }
    }
}
