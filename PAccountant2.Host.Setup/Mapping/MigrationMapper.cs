using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Migration.Currency;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Migration;
using PAccountant2.DAL.DBO.Entities;
using PAccountant2.DAL.DBO.Entities.Currency;

namespace PAccountant2.Host.Setup.Mapping
{
    class MigrationMapper : Profile
    {
        public MigrationMapper()
        {
            CreateMap<ExchangeRatesMigrationViewItem, CurrencyIncomeValueObject>()
                .ForMember(r => r.BaseCode, opt => opt.MapFrom(cur => cur.BaseNumber))
                .ForMember(r => r.ResultCode, opt => opt.MapFrom(cur => cur.ResultNumber));
            CreateMap<CurrencyDataItem, CurrencyDbo>()
                .ReverseMap();

            CreateMap<ExchangeRateDataItem, ExchangeRateDbo>()
                .ForMember(dbo => dbo.BaseCurrencyId, opt => opt.MapFrom(di => di.BaseCurrency.Id))
                .ForMember(dbo => dbo.ResultCurrencyId, opt => opt.MapFrom(di => di.ResultCurrency.Id))
            .ReverseMap();
        }
    }
}
