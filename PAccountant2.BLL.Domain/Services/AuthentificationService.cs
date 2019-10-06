using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using PAccountant2.BLL.Domain.Exceptions.Authentification;
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
            MD5 md5 = EncryptPassword(item.Password);

            var registerModel = new RegisterDataItem
            {
                Email = item.Email,
                Password = md5.Hash
            };

            authDataService.RegisterUser(registerModel);
        }

        private static MD5 EncryptPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return md5;
        }

        public async Task LoginUserAsync(LoginViewItem item)
        {
            var password = await authDataService.GetPaswordByEmailAsync(item.Email);
            var encryptedPassword = EncryptPassword(item.Password);

            if (password == null || !password.SequenceEqual(encryptedPassword.Hash))
            {
                throw new WrongCredentialsException(item.Email);
            }
        }
    }
}
