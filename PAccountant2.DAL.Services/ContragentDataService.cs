using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities;

namespace PAccountant2.DAL.Services
{
    public class ContragentDataService : IContragentDataService
    {
        private readonly PaccountantContext _context;

        public ContragentDataService(PaccountantContext context)
        {
            _context = context;
        }

        public async Task<int> CreateContragent(ContragentDataItem data)
        {
            var contragent = new ContragentDbo
            {
                AccountingId = data.AccountingId,
                Name = data.Name
            };

            _context.Contragents.Add(contragent);
            await _context.SaveChangesAsync();

            return contragent.Id;
        }

        public async Task<ContragentDataItem> Get(string name)
        {
            var dbData = await _context.Contragents.FirstOrDefaultAsync(c =>
                string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));

            var mappedData = new ContragentDataItem()
            {
                AccountingId = dbData.AccountingId,
                Name = dbData.Name,
                Id = dbData.Id
            };

            return mappedData;
        }

        public async Task<bool> IsContragentExists(string name)
            => await _context.Contragents.AnyAsync(c =>
                string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));


    }
}
