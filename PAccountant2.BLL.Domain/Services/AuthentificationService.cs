﻿using AutoMapper;
using PAccountant2.BLL.Domain.Entities.User;
using PAccountant2.BLL.Domain.Exceptions.Authentification;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Authentification;
using System.Threading.Tasks;
using PAccountant2.BLL.Interfaces.Account;

namespace PAccountant2.BLL.Domain.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IMapper _mapper;
        private readonly IAuthentificationDataService _authDataService;
        private readonly IAccountingDataService _accountingDataService;

        public AuthentificationService(IAuthentificationDataService authDataService,
            IMapper mapper, 
            IAccountingDataService accountingDataService)
        {
            _authDataService = authDataService;
            _mapper = mapper;
            _accountingDataService = accountingDataService;
        }

        public async Task<string> RegisterUserAsync(RegisterViewItem item)
        {
            if (await _authDataService.CheckUserExistsAsync(item.Email))
            {
                throw new UserExistsException(item.Email);
            }

            var user = _mapper.Map<UserEntity>(item);
            var credentials = user.CreateCredentials();

            var registerModel = _mapper.Map<RegisterDataItem>(credentials);
            var newUserEmail = await _authDataService.RegisterUserAsync(registerModel);

            await _accountingDataService.CreateAccountingForUser(newUserEmail);

            return newUserEmail;
        }

        public async Task CheckRightCredentialsAsync(LoginViewItem item)
        {
            var currentPassword = await _authDataService.GetPaswordByEmailAsync(item.Email);

            var user = _mapper.Map<UserEntity>(item);
            user.Password = currentPassword;

            var credentials = user.CreateCredentials();

            if (!credentials.IsPasswordCorrect(item.Password))
            {
                throw new WrongCredentialsException(user.Email);
            }
        }
    }
}
