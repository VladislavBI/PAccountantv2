using System;
using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Domain.Services.Accounting
{
    public class AccountingService : IAccountingService
    {
        private readonly IAccountingDataService _accountingDataService;

        private readonly IMapper _mapper;

        public AccountingService(IAccountingDataService accountingDataService, IMapper mapper)
        {
            _accountingDataService = accountingDataService;
            _mapper = mapper;
        }

        public async Task<AccountingWithAccountsViewItem> GetAccountingWithAccountsAsync(int id, AccountFilterViewItem mappedFilters)
        {
            var accounting = new AccountingEntity();
            var accountingSpecification = accounting.CreateSpecification(mappedFilters);

            var accountingDbData = await _accountingDataService.GetAccountingWithAccounts(id, accountingSpecification);

            _mapper.Map(accountingDbData, accounting);

            accounting.CheckMissingAccounting();
            accounting.Summ = accounting.CalculateSumm();

            var viewAccounting = _mapper.Map<AccountingWithAccountsViewItem>(accounting);

            return viewAccounting;
        }

        public async Task TransferMoneyToOtherAccountAsync(int accId, int fromId, AccountTransferViewItem viewData)
        {
            var accountingWithAccounts = await _accountingDataService.GetAccountingWithAccounts(accId, null);

            var accounting = new AccountingEntity();
            _mapper.Map(accountingWithAccounts, accounting);

            var transferValueObject = accounting.TransferMoneyBeetwenAccount(fromId, viewData.IdAccountForTranser, viewData.Amount);

            var dbTransfer = _mapper.Map<AccountTransferDataItem>(transferValueObject);

            await _accountingDataService.TransferMoneyToOtherAccountAsync(dbTransfer);
        }
    }
}
