using System;
using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Domain.Entities.Investment;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using PAccountant2.BLL.Interfaces.Investment;
using PAccountant2.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAccountant2.BLL.Domain.Services.Investment
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IMapper _mapper;
        private readonly IInvestmentDataService _investmentService;
        private readonly IContragentDataService _contragentService;

        public InvestmentService(IMapper mapper, IInvestmentDataService investmentService, IContragentDataService contragentService)
        {
            _mapper = mapper;
            _investmentService = investmentService;
            _contragentService = contragentService;
        }

        public async Task AddMoneyAutoAsync()
        {
            var investmentsDb = await _investmentService.GetAutoUpdateInvestments();

            var investments = _mapper.Map<IEnumerable<InvestmentEntity>>(investmentsDb);

            foreach (var investment in investments)
            {
                if (investment.IsPaymentPeriod())
                {
                    var newOperation = investment.AddNewPaymentAuto(DateTime.Now, "Auto payment");

                    var dbInvestment = _mapper.Map<InvestmentDataItem>(investment);
                    var mappedOperation = _mapper.Map<InvestmentOperationDataItem>(newOperation);

                    await _investmentService.UpdateInvestmentAsync(dbInvestment);
                    await _investmentService.AddInvestmentOperationAsync(dbInvestment.Id, mappedOperation);
                }
            }
        }

        public async Task<int> AddNewInvestment(int acctingId, int invType, AddInvestmentViewItem mappedModel)
        {
            var contragent = new ContragentEntity();
            var contragentId = await contragent.GetOrCreateContragentIdByName
                (_contragentService, mappedModel.ContragentName, acctingId);

            var term = DateHelper.CreateTimeSpan(mappedModel.From, mappedModel.To);

            var dbInvestment = _mapper.Map<AddInvestmentDataItem>(mappedModel);
            dbInvestment.ContragentId = contragentId;
            dbInvestment.Term = term;
            dbInvestment.AccountingId = acctingId;
            dbInvestment.InvestmentType = invType;

            int newLoanId = await _investmentService.AddNewInvestment(dbInvestment);

            return newLoanId;
        }
    }
}
