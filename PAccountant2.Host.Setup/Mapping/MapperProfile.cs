﻿using AutoMapper;
using PAccountant2.BLL.Domain.Entities;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using PAccountant2.DAL.DBO.Entities;
using PAccountant2.Host.Domain.ViewModels.Account;
using PAccountant2.Host.Domain.ViewModels.Authentification;

namespace PAccountant2.Host.Setup.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegistrationViewModel, RegisterViewItem>();
            CreateMap<LoginViewModel, LoginViewItem>();

            CreateMap<AddMoneyViewModel, AddMoneyViewItem>();
            CreateMap<AddMoneyViewItem, AddMoneyDataItem>();
            CreateMap<AddMoneyDataItem, AccountEntity>();
            CreateMap<AccountEntity, AddMoneyDataItem>();
            CreateMap<AddMoneyDataItem, AccountDbo>();
            CreateMap<AccountDbo, AddMoneyDataItem>();

        }
    }
}
