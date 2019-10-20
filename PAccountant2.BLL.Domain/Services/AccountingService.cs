using AutoMapper;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using System.Threading.Tasks;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;

namespace PAccountant2.BLL.Domain.Services
{
    public class AccountingService: IAccountingService
    {
        private readonly IAccountingDataService _accountingDataService;

        private readonly IMapper _mapper;

        public AccountingService(IAccountingDataService accountingDataService, IMapper mapper)
        {
            _accountingDataService = accountingDataService;
            _mapper = mapper;
        }

        public async Task<AccountingWithAccountsViewItem> GetAccountingWithAccountsAsync(int id)
        {
            var dbData = await _accountingDataService.GetAccountingWithAccounts(id);

            var viewAccounting = _mapper.Map<AccountingWithAccountsViewItem>(dbData);

            return viewAccounting;
        }

        public async Task TransferMoneyToOtherAccountAsync(int accId, int fromId, AccountTransferViewItem viewData)
        {
            var accountingWithAccounts = await _accountingDataService.GetAccountingWithAccounts(accId);
            var accounting = _mapper.Map<AccountingEntity>(accountingWithAccounts);

            var transferValueObject = accounting.TransferMoneyBeetwenAccount(fromId, viewData.IdAccountForTranser, viewData.Amount);

            var dbTransfer = _mapper.Map<AccountTransferDataItem>(transferValueObject);

            await _accountingDataService.TransferMoneyToOtherAccountAsync(dbTransfer);
        }
    }
}
