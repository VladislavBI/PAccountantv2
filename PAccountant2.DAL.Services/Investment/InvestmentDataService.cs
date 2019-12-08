using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using PAccountant2.BLL.Interfaces.Investment;
using PAccountant2.DAL.Context;
using PAccountant2.DAL.DBO.Entities.Investment;
using System.Collections.Generic;
using System.Linq;
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
                StartBodyAmount = dbInvestment.StartBodyAmount,
                CurrentBodyAmount = dbInvestment.StartBodyAmount,
                InvestmentType = dbInvestment.InvestmentType,
                Percent = dbInvestment.Percent,
                PaymentPeriod = dbInvestment.PaymentType,
                StartDate = dbInvestment.StartDate,
                CurrencyId = dbInvestment.CurrencyId,
                MoneyIncomeOption = dbInvestment.MoneyIncomeOption
            };

            accounting.Investments.Add(dbData);
            await _context.SaveChangesAsync();

            return dbData.Id;
        }

        public async Task<IEnumerable<InvestmentDataItem>> GetAutoUpdateInvestments()
        {
            var investments = await _context.Investments
                .Include(x => x.Operations)
                .Where(x => x.MoneyIncomeOption == 1 && !x.Completed)
                .ToListAsync();

            foreach (var inv in investments)
            {
                var lastPaymentDate = inv.StartDate;

                if (inv?.Operations != null && inv.Operations.Any())
                {
                    lastPaymentDate = inv.Operations.Max(op => op.Date);

                }
            }
            var lastOperations = investments.Select(inv =>
            {
                var lastPaymentDate = inv.StartDate;

                if (inv?.Operations != null && inv.Operations.Any())
                {
                    lastPaymentDate = inv.Operations.Max(op => op.Date);

                }
                return new { inv.Id, lastPaymentDate };
            });

            var mappedInv = _mapper.Map<IEnumerable<InvestmentDataItem>>(investments);

            mappedInv = mappedInv.Join(lastOperations, inv => inv.Id, op => op.Id, (inv, op) =>
            {
                inv.LastPayment = op.lastPaymentDate;
                return inv;
            });

            return mappedInv;
        }

        public async Task UpdateInvestmentAsync(InvestmentDataItem dbInvestment)
        {
            var investment = await _context.Investments.FirstOrDefaultAsync(inv => inv.Id == dbInvestment.Id);

            investment.CurrentBodyAmount = dbInvestment.CurrentBodyAmount;
            investment.Completed = dbInvestment.Completed;

            await _context.SaveChangesAsync();
        }

        public async Task AddInvestmentOperationAsync(int dbInvestmentId, InvestmentOperationDataItem mappedOperation)
        {
            var investment = await _context.Investments
                .Include(x => x.Operations)
                .FirstOrDefaultAsync(inv => inv.Id == dbInvestmentId);

            var newOperation = new InvestmentOperationDbo
            {
                Amount = mappedOperation.Amount,
                Comment = mappedOperation.Comment,
                CurrencyId = 1,
                Date = mappedOperation.Date,
                NewTotalAmount = mappedOperation.NewTotalAmount
            };

            investment.Operations.Add(newOperation);

            await _context.SaveChangesAsync();
        }
    }
}
