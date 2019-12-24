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
            CreateMap<WheelOfLifeProblemViewItem, WheelOfLifeProblemDataItem>();
            CreateMap<WheelOfLifeProblemDataItem, WheelOfLifeProblemDbo>()
                .ReverseMap();
            CreateMap<WheelOfLifeElementEntity, WheelOfLifeElementDataItem>()
                .ReverseMap();
            CreateMap<WheelOfLifeElementDbo, WheelOfLifeElementDataItem>()
                .ReverseMap();
            CreateMap<WheelOfLifePlanAddViewModel, WheelOfLifePlanViewItem>();
            CreateMap<WheelOfLifePlanViewItem, WheelOfLifePlanDataItem>();
            CreateMap<WheelOfLifePlanDataItem, WheelOfLifePlanDbo>();
        }
    }
}
