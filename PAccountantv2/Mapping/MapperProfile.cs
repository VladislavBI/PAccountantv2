using AutoMapper;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountantv2.Host.Api.ViewModels.Authentification;

namespace PAccountantv2.Host.Api.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegistrationViewModel, RegisterViewItem>();
        }
    }
}
