using PAccountant2.BLL.Domain.Entities.WheelOfLife;
using PAccountant2.BLL.Interfaces.DTO.DataItems.WheelOfLife;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.WheelOfLife;
using PAccountant2.DAL.DBO.Entities.WheelOfLife;
using PAccountant2.Host.Domain.ViewModels.WheelOfLife;

namespace PAccountant2.Host.Setup.Mapping
{
    class WheelOfLifeMapping : MapperProfile
    {
        public WheelOfLifeMapping()
        {
            CreateMap<WheelOfLifeProblemAddViewModel, WheelOfLifeProblemViewItem>();
            CreateMap<WheelOfLifeProblemViewItem, WheelOfLifeProblemDataItem>()
                .ReverseMap();
            CreateMap<WheelOfLifeProblemDataItem, WheelOfLifeProblemDbo>()
                .ReverseMap();
            CreateMap<WheelOfLifeElementEntity, WheelOfLifeElementDataItem>()
                .ReverseMap();
            CreateMap<WheelOfLifeProblemEntity, WheelOfLifeProblemDataItem>()
                .ReverseMap();
            CreateMap<WheelOfLifePlanEntity, WheelOfLifePlanDataItem>()
                .ReverseMap();
            CreateMap<WheelOfLifeElementDbo, WheelOfLifeElementDataItem>()
                .ReverseMap();
            CreateMap<WheelOfLifePlanAddViewModel, WheelOfLifePlanViewItem>();
            CreateMap<WheelOfLifePlanViewItem, WheelOfLifePlanDataItem>()
                .ReverseMap();
            CreateMap<WheelOfLifePlanDataItem, WheelOfLifePlanDbo>()
                .ReverseMap();
            CreateMap<WheelOfLifeElementDbo, WheelOfLifeElementDataItem>();
            CreateMap<WheelOfLifeElementDataItem, WheelOfLifeElementViewItem>();
            CreateMap<WheelOfLifeElementViewItem, WheelOfLifeElementViewModel>();
            CreateMap<WheelOfLifeProblemViewItem, WheelOfLifeProblemViewModel>();
            CreateMap<WheelOfLifePlanViewItem, WheelOfLifePlanViewModel>();

            CreateMap<WheelOfLifeMementoDbo, WheelOfLifeMementoDataItem>();
            CreateMap<WheelOfLifeMementoDataItem, WheelOfLifeMementoEntity>();
            CreateMap<WheelOfLifeMementoDateValueObject, WheelOfLifeMementoDateViewItem>();
            CreateMap<WheelOfLifeMementoDateViewItem, WheelOfLifeMementoDateViewModel>();
        }
    }
}
