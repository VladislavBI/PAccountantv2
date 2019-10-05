using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;

namespace PAccountant2.BLL.Domain.Services
{
    public class AuthentificationService: IAuthentificationService
    {
        private readonly IMapper mapper;
        private readonly IAuthentificationDataService authDataService;

        public AuthentificationService(IMapper mapper,
            IAuthentificationDataService authDataService)
        {
            this.mapper = mapper;
            this.authDataService = authDataService;
        }
        public void RegisterUser(RegisterViewItem item)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(item.Password));

            var registerModel = new RegisterDataItem
            {
                Email =  item.Email,
                Password = md5.Hash
            };
            
            authDataService.RegisterUser(registerModel);
        }
    }
}
