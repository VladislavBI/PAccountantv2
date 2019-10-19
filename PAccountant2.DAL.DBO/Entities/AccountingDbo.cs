using System.Collections.Generic;

namespace PAccountant2.DAL.DBO.Entities
{
    public class AccountingDbo
    {
        public int Id { get; set; }

        public UserDbo User { get; set; }

        public string UserEmail { get; set; }

        public ICollection<AccountDbo> Accounts { get; set; }
    }
}
