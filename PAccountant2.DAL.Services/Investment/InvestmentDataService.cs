using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using PAccountant2.BLL.Interfaces.Investment;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities.Investment;

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

        public async Task<int> AddLoanTo(AddLoanDataItem dbInvestment)
        {
            var accounting = await _context.Accountings
                .Include(acc => acc.Investments)
                .FirstOrDefaultAsync(acc => acc.Id == dbInvestment.AccountingId);

            var dbData = new InvestmentDbo
            {
                Term = (long)dbInvestment.Term.TotalDays,
                BodyAmount = dbInvestment.BodyAmount,
                InvestmentType = 1,
                Percent = dbInvestment.Percent,
                PaymentPeriod = dbInvestment.PaymentType,
                StartDate = dbInvestment.StartDate
            };

            accounting.Investments.Add(dbData);
            await _context.SaveChangesAsync();

            return dbData.Id;
        }

        public async Task<int> AddLoanFrom(AddLoanDataItem dbInvestment)
        {
            var accounting = await _context.Accountings
                .Include(acc => acc.Investments)
                .FirstOrDefaultAsync(acc => acc.Id == dbInvestment.AccountingId);

            var dbData = new InvestmentDbo
            {
                Term = (long)dbInvestment.Term.TotalDays,
                BodyAmount = dbInvestment.BodyAmount,
                InvestmentType = 2,
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
