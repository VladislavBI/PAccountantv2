using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Account;
using PAccountant2.BLL.Interfaces.DTO.ViewItems.Accounting;
using PAccountant2.Host.Domain.ViewModels.Account;
using PAccountant2.Host.Domain.ViewModels.Accounting;
using System.Threading.Tasks;

namespace PAccountantv2.Host.Api.Controllers
{
    [Route("api/accounting/{id}")]
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

        /// <summary>
        /// Get accounting with accounts
        /// </summary>
        /// <param name="id">id of accounting to get</param>
        /// <param name="filters">filtered data</param>
        /// <response code="200">accounting with accounts filtered</response>
        [HttpGet]
        public async Task<IActionResult> GetAccountingWithAccounts(int id, [FromQuery]AccountFilterViewModel filters)
        {
            var mappedFilters = _mapper.Map<AccountFilterViewItem>(filters);
            var accountingModel = await _accountingService.GetAccountingWithAccountsAsync(id, mappedFilters);

            var mappedData = _mapper.Map<AccountingWithAccountsViewModel>(accountingModel);

            return Ok(mappedData);
        }

        [Route("options")]
        [HttpGet]
        public async Task<IActionResult> GetOptionsForAccounting(int id)
        {
            AccountingOptionsViewItem accountOptions = await _accountingService.GetOptionsAsync(id);

            var mappedOptions = _mapper.Map<AccountingOptionsViewModel>(accountOptions);

            return Ok(mappedOptions);
        }

        [Route("options")]
        [HttpPut]
        public async Task<IActionResult> UpdateOptions(int id, AccountingOptionsViewItem options)
        {
            var mappedOptions = _mapper.Map<AccountingOptionsViewItem>(options);

            await _accountingService.UpdateOptionsAsync(id, options);

            return Ok();
        }
    }
}