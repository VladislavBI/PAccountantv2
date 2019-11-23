using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Domain.Entities.User;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Migration;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration;
using PAccountant2.DAL.DBO.Entities;
using PAccountant2.DAL.DBO.Entities.Accounting;
using PAccountant2.Host.Domain.ViewModels.Account;
using PAccountant2.Host.Domain.ViewModels.Authentification;

namespace PAccountant2.Host.Setup.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegistrationViewModel, RegisterViewItem>();
            CreateMap<RegisterViewItem, UserEntity>()
                .ForMember(member => member.Password, opt => opt.Ignore())
                .ForMember(member => member.StringPassword, opt => opt.MapFrom(reg => reg.Email));
            CreateMap<CredentialsValueObject, RegisterDataItem>();
            CreateMap<LoginViewModel, LoginViewItem>();
            CreateMap<LoginViewItem, UserEntity>()
                .ForMember(member => member.Password, opt => opt.Ignore());

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

            CreateMap<AccountingDbo, AccountingWithAccountsDataItem>();
            CreateMap<AccountingWithAccountsDataItem, AccountingWithAccountsViewItem>();
            CreateMap<AccountingWithAccountsViewItem, AccountingWithAccountsViewModel>();

            CreateMap<AccountTransferViewModel, AccountTransferViewItem>();
            CreateMap<AccountingWithAccountsDataItem, AccountingEntity>();
            CreateMap<AccountTransferValueObject, AccountTransferDataItem>();

            CreateMap<CurrencyMigrationViewItem, CurrencyMigrationDataItem>();
            CreateMap<CurrencyMigrationDataItem, CurrencyDbo>();


        }
    }
}
