using System;
using System.Collections.Generic;
using System.Linq;
using PAccountant2.BLL.Domain.Exceptions.Account;

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

            CheckIsOperationAvailable(accountFrom, accountTo);

            accountTo.Amount += Amount;
            accountFrom.Amount -= Amount;
        }

        private void CheckIsOperationAvailable(AccountEntity accountFrom, AccountEntity accountTo)
        {
            if (accountFrom == null)
            {
                throw new NullReferenceException($"acccount from is not found");
            }
            accountFrom.CheckIsOperationAvailable(Amount);

            if (accountTo == null)
            {
                throw new NullReferenceException($"acccount to is not found");
            }

            if (accountFrom.Id == accountTo.Id)
            {
                throw new SameAccountTransferException();
            }
        }
    }
}
