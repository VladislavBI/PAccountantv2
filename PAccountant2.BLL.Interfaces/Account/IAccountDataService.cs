using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;

namespace PAccountant2.BLL.Interfaces.Account
{
    public interface IAccountDataService
    {
        Task<AddMoneyDataItem> GetMoneyAmountAsync(int addModelId);
        Task SaveNewMoneyAmountAync(AddMoneyDataItem newAmountDataItem);
    }
}
