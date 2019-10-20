using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.DAL.DBO.Entities;
using PAccountant2.Host.Domain.ViewModels.Account;

namespace PAccountant2.Host.Setup.Mapping
{
    class AccountMapping : Profile
    {
        public AccountMapping()
        {
            CreateMap<MoneyChangeViewModel, MoneyChangeViewItem>();
            CreateMap<MoneyChangeViewItem, MoneyChangeDataItem>();
            CreateMap<MoneyChangeDataItem, AccountDbo>();
            CreateMap<AccountEntity, MoneyChangeDataItem>();

            CreateMap<AccountDbo, AccountBalanceDataItem>();
            CreateMap<AccountBalanceDataItem, AccountEntity>();
            CreateMap<AccountBalanceDataItem, AccountBalanceViewItem>();
            CreateMap<AccountBalanceViewItem, AccountBalanceViewModel>();

            CreateMap<AccountOperationViewItem, AccountOperationViewModel>();
            CreateMap<AccountWithHistotyDataItem, AccountEntity>();
            CreateMap<AccountOperationDataItem, AccountOperationValueObject>();
            CreateMap<AccountOperationValueObject, AccountOperationDataItem>();
            CreateMap<AccountOperationValueObject, AccountOperationViewItem>();
            CreateMap<AccountWithHistotyDataItem, AccountEntity>();
            CreateMap<AccountOperationDataItem, AccountHistoryValueObject>();
            CreateMap<AccountOperationDbo, AccountOperationDataItem>();
            CreateMap<AccountOperationDataItem, AccountOperationDbo>();
            CreateMap<AccountOperationValueObject, AccountOperationDataItem>();
        }
    }
}
