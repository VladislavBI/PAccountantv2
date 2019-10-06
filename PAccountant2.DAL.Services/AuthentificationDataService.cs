using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<byte[]> GetPaswordByEmailAsync(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => string.Equals(x.Email, email));
            return user?.Password ?? null;
        }
    }
}
