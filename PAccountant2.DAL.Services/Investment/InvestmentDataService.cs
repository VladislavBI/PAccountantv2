using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using PAccountant2.BLL.Interfaces.Investment;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities.Investment;
using System.Threading.Tasks;

namespace PAccountant2.DAL.Services.Investment
{
    public class InvestmentDataService : IInvestmentDataService
    {
        private readonly IMapper _mapper;
        private readonly PaccountantContext _context;

        public InvestmentDataService(PaccountantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddNewInvestment(AddInvestmentDataItem dbInvestment)
        {
            var accounting = await _context.Accountings
                .Include(acc => acc.Investments)
                .FirstOrDefaultAsync(acc => acc.Id == dbInvestment.AccountingId);

            var dbData = new InvestmentDbo
            {
                Term = (long)dbInvestment.Term.TotalDays,
                BodyAmount = dbInvestment.BodyAmount,
                InvestmentType = dbInvestment.InvestmentType,
                Percent = dbInvestment.Percent,
                PaymentPeriod = dbInvestment.PaymentType,
                StartDate = dbInvestment.StartDate
            };

            accounting.Investments.Add(dbData);
            await _context.SaveChangesAsync();

            return dbData.Id;
        }
    }
}
