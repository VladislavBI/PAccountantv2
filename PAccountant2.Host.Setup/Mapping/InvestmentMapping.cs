using System;
using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Investment;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using PAccountant2.DAL.DBO.Entities.Investment;
using PAccountant2.Host.Domain.ViewModels.Investment;

namespace PAccountant2.Host.Setup.Mapping
{
    public class InvestmentMapping : Profile
    {
        public InvestmentMapping()
        {
            CreateMap<AddInvestmentViewModel, AddInvestmentViewItem>();
            CreateMap<AddInvestmentViewItem, AddInvestmentDataItem>()
                .ForMember(x => x.StartBodyAmount, conf => conf.MapFrom(x => x.Sum))
                .ForMember(x => x.StartDate, conf => conf.MapFrom(x => x.From))
                .ForMember(x => x.AccountingId, conf => conf.Ignore())
                .ForMember(x => x.ContragentId, conf => conf.Ignore())
                .ForMember(x => x.Term, conf => conf.Ignore());

            CreateMap<InvestmentDataItem, InvestmentDbo>()
                .ForMember(di => di.Term, conf => conf.MapFrom(db => db.Term.Ticks))
                .ReverseMap()
                .ForMember(db => db.Term, conf => conf.MapFrom(db => TimeSpan.FromDays(db.Term)));

            CreateMap<InvestmentDataItem, InvestmentEntity>()
                .ReverseMap();

            CreateMap<InvestmentOperationValueObject, InvestmentOperationDataItem>();
            CreateMap<InvestmentOperationDataItem, InvestmentOperationDbo>();
        }
    }
}
