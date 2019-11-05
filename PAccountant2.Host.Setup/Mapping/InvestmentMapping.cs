using AutoMapper;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using PAccountant2.Host.Domain.ViewModels.Investment;

namespace PAccountant2.Host.Setup.Mapping
{
    public class InvestmentMapping : Profile
    {
        public InvestmentMapping()
        {
            CreateMap<AddLoanViewModel, AddLoanViewItem>();
        }
    }
}
