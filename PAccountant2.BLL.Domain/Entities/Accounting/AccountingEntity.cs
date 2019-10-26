using System;
using PAccountant2.BLL.Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class AccountingEntity
    {
        public int? Id { get; set; }

        public decimal Summ { get; set; }

        public UserEntity User { get; set; }

        public IEnumerable<AccountEntity> Accounts { get; set; }

        public AccountTransferValueObject TransferMoneyBeetwenAccount(int fromId, int toId, decimal amount)
        {
            CheckMissingAccounting();

            var transferValueObject = new AccountTransferValueObject
            {
                Amount = amount,
                IdAccountFrom = fromId,
                IdAccountTo = toId
            };

            transferValueObject.TransferMoneyBeetwenAccount(Accounts);

            return transferValueObject;
        }

        public void CheckMissingAccounting()
        {
            if (!Id.HasValue)
            {
                throw new NullReferenceException($"accounting with id {Id} was not found");
            }
        }

        public decimal CalculateSumm()
        {
            return Accounts.Sum(acc => acc.Amount);
        }
    }
}
