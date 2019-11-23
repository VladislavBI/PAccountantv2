using PAccountant2.DAL.DBO.Entities.Currency;

namespace PAccountant2.DAL.DBO.Entities.Accounting
{
    public class AccountingOptionsDbo
    {
        public int AccountingId { get; set; }

        public AccountingDbo Accounting { get; set; }

        public int AccountingBaseCurrencyId { get; set; }

        public CurrencyDbo AccountingBaseCurrency { get; set; }
    }
}
