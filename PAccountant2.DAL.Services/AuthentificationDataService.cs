using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PAccountant2.DAL.Services
{

    public class AuthentificationDataService : IAuthentificationDataService
    {
        private readonly PaccountantContext _context;

        public AuthentificationDataService(PaccountantContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterUserAsync(RegisterDataItem item)
        {
            var newUser = new UserDbo
            {
                Email = item.Email,
                Password = item.Password
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser.Email;
        }

        public async Task<byte[]> GetPaswordByEmailAsync(string email)
        {
            var dbUser = await _context.Users
                .Where(user => string.Equals(user.Email, email, StringComparison.CurrentCultureIgnoreCase))
                .Select(user => user.Password)
                .FirstOrDefaultAsync();

            return dbUser;
        }

        public async Task<bool> CheckUserExistsAsync(string email)
            => await _context.Users
                .AnyAsync(user => string.Equals(email, user.Email, StringComparison.CurrentCultureIgnoreCase));
    }
}
