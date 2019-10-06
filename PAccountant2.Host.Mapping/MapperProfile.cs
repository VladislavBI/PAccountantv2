using AutoMapper;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountantv2.Host.Api.ViewModels.Authentification;

namespace PAccountant2.Host.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegistrationViewModel, RegisterViewItem>();
            CreateMap<LoginViewModel, LoginViewItem>();
        }
    }
}
