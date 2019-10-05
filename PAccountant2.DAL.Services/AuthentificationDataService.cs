using System;
using System.Collections.Generic;
using System.Text;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;

namespace PAccountant2.DAL.Services
{
   
    public class AuthentificationDataService: IAuthentificationDataService
    {
        private readonly PaccountantContext context;

        public AuthentificationDataService(PaccountantContext context)
        {
            this.context = context;
        }

        public void RegisterUser(RegisterDataItem item)
        {
            var newUser = new UserDbo
            {
                Email = item.Email,
                Password = item.Password
            };
            context.Users.Add(newUser);
            context.SaveChanges();
        }
    }
}
