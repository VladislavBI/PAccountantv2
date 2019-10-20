using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.DAL.DBO.Entities;
using PAccountant2.Host.Domain.ViewModels.Account;

namespace PAccountant2.Host.Setup.Mapping
{
    class AccountingMapping : Profile
    {
        public AccountingMapping()
        {
            CreateMap<AccountingDbo, AccountingWithAccountsDataItem>();
            CreateMap<AccountingWithAccountsDataItem, AccountingEntity>();
            CreateMap<AccountingEntity, AccountingWithAccountsViewItem>();
            CreateMap<AccountingWithAccountsViewItem, AccountingWithAccountsViewModel>();

            CreateMap<AccountingWithAccountsDataItem, AccountEntity>();
            CreateMap<AccountEntity, AccountingWithAccountsViewItem>();
            CreateMap<AccountingWithAccountsViewItem, AccountingWithAccountsViewModel>();
        }
    }
}
