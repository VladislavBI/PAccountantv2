using System.Threading.Tasks;
using AutoMapper;
using PAccountant2.BLL.Domain.Entities.Accounting;
using PAccountant2.BLL.Domain.Entities.Investment;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Authentification;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Investment;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Investment;
using PAccountant2.BLL.Interfaces.Investment;
using PAccountant2.Common;

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

        public async Task<int> AddLoanToAsync(int acctingId, AddLoanViewItem mappedModel)
        {
            int contragentId;

            if (await _contragentService.IsContragentExists(mappedModel.ContragentName))
            {
                var data = await _contragentService.Get(mappedModel.ContragentName);
                contragentId = data.Id;
            }
            else
            {
                var dbData = new ContragentDataItem()
                {
                    AccountingId = acctingId,
                    Name = mappedModel.ContragentName
                };

                contragentId = await _contragentService.CreateContragent(dbData);
            }

            var term = DateHelper.CreateTimeSpan(mappedModel.From, mappedModel.To);

            var dbInvestment = new AddLoanDataItem
            {
                BodyAmount = mappedModel.Sum,
                PaymentType = mappedModel.PaymentType,
                ContragentId = contragentId,
                Percent = mappedModel.Percent,
                StartDate = mappedModel.From,
                Term = term,
                AccountingId = acctingId
            };

            int newLoanId = await _investmentService.AddLoanTo(dbInvestment);

            return newLoanId;
        }
    }
}
