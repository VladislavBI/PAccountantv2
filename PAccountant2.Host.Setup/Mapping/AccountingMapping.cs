using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Accounting;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Accounting;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Currency;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.DAL.DBO.Entities.Currency;
using PAccountant2.Host.Domain.ViewModels.Accounting;
using PAccountant2.Host.Domain.ViewModels.Currency;

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

            CreateMap<AccountingOptionsDbo, AccountingOptionsEntity>()
                .ReverseMap();

            CreateMap<AccountingOptionsDbo, AccountingOptionsDataItem>();
            CreateMap<AccountingOptionsDataItem, AccountingOptionsViewItem>();
            CreateMap<AccountingOptionsViewItem, AccountingOptionsViewModel>();

            CreateMap<CurrencyDbo, CurrencyDataItem>();
            CreateMap<CurrencyDataItem, CurrencyViewItem>();
            CreateMap<CurrencyViewItem, CurrencyViewModel>();

        }
    }
}
