using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.Host.Domain.ViewModels.Account;
using System.Threading.Tasks;

namespace PAccountantv2.Host.Api.Controllers
{
    [Route("api/accounting")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountingService _accountingService;

        private readonly IMapper _mapper;

        public AccountingController(IAccountingService accountingService, IMapper mapper)
        {
            _accountingService = accountingService;
            _mapper = mapper;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAccountingWithAccounts(int id)
        {
            var accountingModel = await _accountingService.GetAccountingWithAccountsAsync(id);

            var mappedData = _mapper.Map<AccountingWithAccountsViewModel>(accountingModel);

            return Ok(mappedData);
        }

        [Route("{id}/account/{accId}")]
        [HttpPost]
        public async Task TransferMoneyBeetwenAccountsAsync(int id, int accId, AccountTransferViewModel model)
        {
            var viewData = _mapper.Map<AccountTransferViewItem>(model);

            await _accountingService.TransferMoneyToOtherAccountAsync(id, accId, viewData);
        }
    }
}