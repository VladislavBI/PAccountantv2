using System.Collections.Generic;
using PAccountant2.BLL.Domain.Entities.User;

namespace PAccountant2.BLL.Domain.Entities.Accounting
{
    public class AccountingEntity
    {
        public int Id { get; set; }

        public UserEntity User { get; set; }

        public IEnumerable<AccountEntity> Accounts { get; set; }
    }
}
