using AutoMapper;
using PAccountant2.BLL.Domain.Entities.User;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountant2.Host.Domain.ViewModels.Authentification;

namespace PAccountant2.Host.Setup.Mapping
{
    public class AuthMapping : Profile
    {
        public AuthMapping()
        {
            CreateMap<RegistrationViewModel, RegisterViewItem>();
            CreateMap<RegisterViewItem, UserEntity>()
                .ForMember(member => member.Password, opt => opt.Ignore())
                .ForMember(member => member.StringPassword, opt => opt.MapFrom(reg => reg.Email));
            CreateMap<CredentialsValueObject, RegisterDataItem>();
            CreateMap<LoginViewModel, LoginViewItem>();
            CreateMap<LoginViewItem, UserEntity>()
                .ForMember(member => member.Password, opt => opt.Ignore());
        }
    }
}
