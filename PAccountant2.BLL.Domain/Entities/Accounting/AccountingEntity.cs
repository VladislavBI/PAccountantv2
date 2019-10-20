using PAccountant2.BLL.Domain.Entities.User;
using System.Collections.Generic;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class AccountingEntity
    {
        public int Id { get; set; }

        public UserEntity User { get; set; }

        public IEnumerable<AccountEntity> Accounts { get; set; }

        public AccountTransferValueObject TransferMoneyBeetwenAccount(int fromId, int toId, decimal amount)
        {
            var transferValueObject = new AccountTransferValueObject
            {
                Amount = amount,
                IdAccountFrom = fromId,
                IdAccountTo = toId
            };

            transferValueObject.TransferMoneyBeetwenAccount(Accounts);

            return transferValueObject;
        }
    }
}
