using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.BLL.Interfaces.DTO.DataItems.Account
{
    public class AccountWithHistotyDataItem
    {
        public int Id { get; set; }

        public IEnumerable<AccountOperationDataItem> AccountOperations { get; set; }
    }
}
