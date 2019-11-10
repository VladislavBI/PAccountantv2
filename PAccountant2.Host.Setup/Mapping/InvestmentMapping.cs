using System.Configuration;
using AutoMapper;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using PAccountant2.Host.Domain.ViewModels.Investment;

namespace PAccountant2.Host.Setup.Mapping
{
    public class InvestmentMapping : Profile
    {
        public InvestmentMapping()
        {
            CreateMap<AddInvestmentViewModel, AddLoanViewItem>();
            CreateMap<AddLoanViewItem, AddInvestmentDataItem>()
                .ForMember(x => x.BodyAmount, conf => conf.MapFrom(x => x.Sum))
                .ForMember(x => x.StartDate, conf => conf.MapFrom(x => x.From))
                .ForMember(x => x.AccountingId, conf => conf.Ignore())
                .ForMember(x => x.ContragentId, conf => conf.Ignore())
                .ForMember(x => x.Term, conf => conf.Ignore());
        }
    }
}
