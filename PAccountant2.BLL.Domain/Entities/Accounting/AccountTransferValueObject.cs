using System.Collections.Generic;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class AccountTransferValueObject
    {
        public decimal Amount { get; set; }

        public int IdAccountFrom { get; set; }

        public int IdAccountTo { get; set; }

        public void TransferMoneyBeetwenAccount(IEnumerable<AccountEntity> accounts)
        {
            var accountFrom = accounts.FirstOrDefault(x => x.Id == IdAccountFrom);
            var accountTo = accounts.FirstOrDefault(x => x.Id == IdAccountTo);

            accountTo.Amount += Amount;
            accountFrom.Amount -= Amount;
        }
    }
}
